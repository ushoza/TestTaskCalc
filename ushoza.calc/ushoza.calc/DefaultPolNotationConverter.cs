using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public class DefaultPolNotationConverter : IConverter
    {
        public Queue<Token> Convert(List<Token> source)
        {
            Queue<Token> result = new Queue<Token>();
            Stack<Token> temp = new Stack<Token>();
            foreach (Token token in source)
            {
                if (token is TokenOperand)
                {
                    //rezult.Enqueue
                    result.Enqueue(token);
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
                            result.Enqueue(temp.Pop());
                        }
                        temp.Pop();


                    }
                }

                if (token is DafaultTokenOperation && !(token is TokenBracket))
                {
                    if (temp.Count != 0)
                    {
                        DafaultTokenOperation operTop = temp.Peek() as DafaultTokenOperation;
                        if (temp.Peek() is TokenBracket || operTop.Priority < (token as DafaultTokenOperation).Priority)
                        {
                            temp.Push(token);
                        }
                        else
                        {
                            DafaultTokenOperation oper = temp.Pop() as DafaultTokenOperation;
                            result.Enqueue(oper);
                            while (temp.Count != 0 && (temp.Peek() as DafaultTokenOperation).Priority >= (token as DafaultTokenOperation).Priority)
                            {
                                oper = temp.Pop() as DafaultTokenOperation;
                                result.Enqueue(oper);
                            }
                            temp.Push(token);
                        }
                    }

                    else
                    {
                        DafaultTokenOperation operTop2 = token as DafaultTokenOperation;
                        temp.Push(operTop2);
                    }
                }


            }
            while (temp.Count != 0)
            {
                DafaultTokenOperation oper = temp.Pop() as DafaultTokenOperation;
                result.Enqueue(oper);
            }
            return result;
        }
    
    }
}