using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ushoza.calc.Exceptions;

namespace ushoza.calc
{
    /// <summary>
    /// Калькулятор (ариметическое логическое устройство)
    /// </summary>
    public class DefaultAlu
    {
        protected virtual IConverter CreateConverter()
        {
            return new DefaultPolNotationConverter();
        }
        public virtual decimal Calc(List<Token> source)
        {
            IConverter converter =  CreateConverter();
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> polNotation = new Queue<Token>();
            polNotation = converter.Convert(source);
            while (polNotation.Count != 0)
            {
                if (polNotation.Peek() is TokenOperand)
                {
                    temp.Push(polNotation.Dequeue());
                }
                else
                {
                    DafaultTokenOperation operation = polNotation.Dequeue() as DafaultTokenOperation;
                    ExecuteOperation(temp, operation);
                }
            }
            if (temp.Count == 1)
            {
                decimal rez = Convert.ToDecimal(temp.Pop().Value);
                return rez;
            }
            else
            {
                throw new CalcException("количество значений в результирующем стэке не равно 1");
            }



        }

        public virtual void ExecuteOperation(Stack<Token> temp, DafaultTokenOperation operation)
        {
            TokenOperand op2 = temp.Pop() as TokenOperand;
            TokenOperand op1 = temp.Pop() as TokenOperand;
            switch (operation.Value.ToString())
            {
                case "+":
                    {
                        decimal r = Convert.ToDecimal(op1.Value) + Convert.ToDecimal(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "-":
                    {
                        decimal r = Convert.ToDecimal(op1.Value) - Convert.ToDecimal(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "*":
                    {
                        decimal r = Convert.ToDecimal(op1.Value) * Convert.ToDecimal(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "/":
                    {
                        decimal r = Convert.ToDecimal(op1.Value) / Convert.ToDecimal(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "^":
                    {
                        decimal r = (int)Math.Round(Math.Pow(Convert.ToDouble(op1.Value), Convert.ToDouble(op2.Value)), 0);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                default:
                    break;
            }
        }

        //public virtual void GetPolishNotation(List<Token> source, Queue<Token> rezult)
        //{
        //    Stack<Token> temp = new Stack<Token>();
        //    foreach (Token token in source)
        //    {
        //        if (token is TokenOperand)
        //        {
        //            //rezult.Enqueue
        //            rezult.Enqueue(token);
        //        }
        //        if (token is TokenBracket)
        //        {
        //            if ((token as TokenBracket).isOpened)
        //            {
        //                temp.Push(token);
        //            }
        //            else
        //            {
        //                while (!(temp.Peek() is TokenBracket))
        //                {
        //                    rezult.Enqueue(temp.Pop());
        //                }
        //                temp.Pop();


        //            }
        //        }

        //        if (token is DafaultTokenOperation && !(token is TokenBracket))
        //        {
        //            if (temp.Count != 0)
        //            {
        //                DafaultTokenOperation operTop = temp.Peek() as DafaultTokenOperation;
        //                if (operTop.Priority < (token as DafaultTokenOperation).Priority)
        //                {
        //                    temp.Push(token);
        //                }
        //                else
        //                {
        //                    DafaultTokenOperation oper = temp.Pop() as DafaultTokenOperation;
        //                    rezult.Enqueue(oper);
        //                    while (temp.Count != 0 && (temp.Peek() as DafaultTokenOperation).Priority >= (token as DafaultTokenOperation).Priority)
        //                    {
        //                        oper = temp.Pop() as DafaultTokenOperation;
        //                        rezult.Enqueue(oper);
        //                    }
        //                    temp.Push(token);
        //                }
        //            }

        //            else
        //            {
        //                DafaultTokenOperation operTop2 = token as DafaultTokenOperation;
        //                temp.Push(operTop2);
        //            }
        //        }

               
        //    }
        //    while (temp.Count !=0)
        //    {
        //        DafaultTokenOperation oper = temp.Pop() as DafaultTokenOperation;
        //        rezult.Enqueue(oper);
        //    }
        //}
    }
}