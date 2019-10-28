using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ushoza.calc.Exceptions;

namespace ushoza.calc
{
    //public class DefaultStrategy : Strategy, IStrategy
    //{
    //    public int Calculate(Queue<Token> polNotation)
    //    {
    //        Stack<Token> temp = new Stack<Token>();
    //        while (polNotation.Count != 0)
    //        {
    //            if (polNotation.Peek() is TokenOperand)
    //            {
    //                temp.Push(polNotation.Dequeue());
    //            }
    //            else
    //            {
    //                TokenOperation operation = polNotation.Dequeue() as TokenOperation;
    //                ExecuteOperation(temp, operation);
    //            }
    //        }
    //        if (temp.Count == 1)
    //        {
    //            int rez = Convert.ToInt32(temp.Pop().value);
    //            return rez;
    //        }
    //        else
    //        {
    //            throw new CalcException("количество значений в результирующем стэке не равно 1");
    //        }
            
    //    }

    //    public virtual void ExecuteOperation(Stack<Token> temp, TokenOperation operation)
    //    {
    //        TokenOperand op2 = temp.Pop() as TokenOperand;
    //        TokenOperand op1 = temp.Pop() as TokenOperand;
    //        switch (operation.value.ToString())
    //        {
    //            case "+":
    //                {
    //                    int r = Convert.ToInt32(op1.value) + Convert.ToInt32(op2.value);
    //                    temp.Push(new TokenOperand() { value = r });
    //                    break;
    //                }
    //            case "-":
    //                {
    //                    int r = Convert.ToInt32(op1.value) - Convert.ToInt32(op2.value);
    //                    temp.Push(new TokenOperand() { value = r });
    //                    break;
    //                }
    //            case "*":
    //                {
    //                    int r = Convert.ToInt32(op1.value) * Convert.ToInt32(op2.value);
    //                    temp.Push(new TokenOperand() { value = r });
    //                    break;
    //                }
    //            case "/":
    //                {
    //                    int r = Convert.ToInt32(op1.value) / Convert.ToInt32(op2.value);
    //                    temp.Push(new TokenOperand() { value = r });
    //                    break;
    //                }
    //            case "^":
    //                {
    //                    int r = (int)Math.Round(Math.Pow(Convert.ToInt32(op1.value), Convert.ToInt32(op2.value)),0);
    //                    temp.Push(new TokenOperand() { value = r });
    //                    break;
    //                }
    //            default:
    //                break;
    //        }
    //    }
    //}
}