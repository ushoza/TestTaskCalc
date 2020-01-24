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

                if (token is DefaultTokenOperation && !(token is TokenBracket))
                {
                    if (temp.Count != 0)
                    {
                        DefaultTokenOperation operTop = temp.Peek() as DefaultTokenOperation;
                        if (temp.Peek() is TokenBracket || operTop.Priority < (token as DefaultTokenOperation).Priority)
                        {
                            temp.Push(token);
                        }
                        else
                        {
                            DefaultTokenOperation oper = temp.Pop() as DefaultTokenOperation;
                            result.Enqueue(oper);
                            while (temp.Count != 0 && !(temp.Peek() is TokenBracket) && (temp.Peek() as DefaultTokenOperation).Priority >= (token as DefaultTokenOperation).Priority)
                                                        
                            {
                                oper = temp.Pop() as DefaultTokenOperation;
                                result.Enqueue(oper);
                            }
                            temp.Push(token);
                        }
                    }

                    else
                    {
                        DefaultTokenOperation operTop2 = token as DefaultTokenOperation;
                        temp.Push(operTop2);
                    }
                }


            }
            while (temp.Count != 0)
            {
                DefaultTokenOperation oper = temp.Pop() as DefaultTokenOperation;
                result.Enqueue(oper);
            }
            return result;
        }
    
    }
}