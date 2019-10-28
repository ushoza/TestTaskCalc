using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ushoza.calc.Exceptions;

namespace ushoza.calc
{
    public class Alu
    {

        public virtual int Calc(List<Token> source)
        {
            
            Stack<Token> temp = new Stack<Token>();
            Queue<Token> polNotation = new Queue<Token>();
            GetPolishNotation(source, temp, polNotation);
            temp = new Stack<Token>();
            while (polNotation.Count != 0)
            {
                if (polNotation.Peek() is TokenOperand)
                {
                    temp.Push(polNotation.Dequeue());
                }
                else
                {
                    TokenOperation operation = polNotation.Dequeue() as TokenOperation;
                    ExecuteOperation(temp, operation);
                }
            }
            if (temp.Count == 1)
            {
                int rez = Convert.ToInt32(temp.Pop().Value);
                return rez;
            }
            else
            {
                throw new CalcException("количество значений в результирующем стэке не равно 1");
            }



        }

        public virtual void ExecuteOperation(Stack<Token> temp, TokenOperation operation)
        {
            TokenOperand op2 = temp.Pop() as TokenOperand;
            TokenOperand op1 = temp.Pop() as TokenOperand;
            switch (operation.Value.ToString())
            {
                case "+":
                    {
                        int r = Convert.ToInt32(op1.Value) + Convert.ToInt32(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "-":
                    {
                        int r = Convert.ToInt32(op1.Value) - Convert.ToInt32(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "*":
                    {
                        int r = Convert.ToInt32(op1.Value) * Convert.ToInt32(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "/":
                    {
                        int r = Convert.ToInt32(op1.Value) / Convert.ToInt32(op2.Value);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                case "^":
                    {
                        int r = (int)Math.Round(Math.Pow(Convert.ToInt32(op1.Value), Convert.ToInt32(op2.Value)), 0);
                        temp.Push(new TokenOperand() { Value = r });
                        break;
                    }
                default:
                    break;
            }
        }

        public virtual void GetPolishNotation(List<Token> source, Stack<Token> temp, Queue<Token> rezult)
        {
            foreach (Token token in source)
            {
                if (token is TokenOperand)
                {
                    //rezult.Enqueue
                    rezult.Enqueue(token);
                }
                if (token is TokenBracket)
                {
                    if ((token as TokenBracket).isOpened)
                    {
                        temp.Push(token);
                    }
                    else
                    {
                        while (!(temp.Peek() is TokenBracket))
                        {
                            rezult.Enqueue(temp.Pop());
                        }
                        temp.Pop();


                    }
                }

                if (token is TokenOperation && !(token is TokenBracket))
                {
                    if (temp.Count != 0)
                    {
                        TokenOperation operTop = temp.Peek() as TokenOperation;
                        if (operTop.Priority < (token as TokenOperation).Priority)
                        {
                            temp.Push(token);
                        }
                        else
                        {
                            TokenOperation oper = temp.Pop() as TokenOperation;
                            rezult.Enqueue(oper);
                            while (temp.Count != 0 && (temp.Peek() as TokenOperation).Priority >= (token as TokenOperation).Priority)
                            {
                                oper = temp.Pop() as TokenOperation;
                                rezult.Enqueue(oper);
                            }
                            temp.Push(token);
                        }
                    }

                    else
                    {
                        TokenOperation operTop2 = token as TokenOperation;
                        temp.Push(operTop2);
                    }
                }

               
            }
            while (temp.Count !=0)
            {
                TokenOperation oper = temp.Pop() as TokenOperation;
                rezult.Enqueue(oper);
            }
        }
    }
}