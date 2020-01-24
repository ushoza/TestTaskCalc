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
                    DefaultTokenOperation operation = polNotation.Dequeue() as DefaultTokenOperation;
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

        public virtual void ExecuteOperation(Stack<Token> temp, DefaultTokenOperation operation)
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

        
    }
}