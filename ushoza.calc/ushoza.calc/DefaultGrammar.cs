using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ushoza.calc.Exceptions;
namespace ushoza.calc
{
    /// <summary>
    /// Грамматика для простейшего парсера математических выражений
    /// </summary>
    public class DefaultGrammar : IGrammar
    {
        public virtual Token GetToken(string expression)
        {
            string dec_sep = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string expressionNew = expression.Replace(" ", "");
            TokenOperand  operand = new TokenOperand();
            operand.Value = "";
            DefaultTokenOperation operation = new DefaultTokenOperation();
            operation.Value = "";
            TokenBracket tokenBracket = new TokenBracket();
            tokenBracket.Value = "";           
            for (int i = 0; i < expressionNew.Length; i++)
            {
                Char cCh = expressionNew[i];
                if (Char.IsDigit(cCh) || cCh.ToString() == dec_sep)
                {
                    operand.Value = String.Format("{0}{1}", operand.Value, cCh);
                }
                else
                {
                    if (CheckEligibleOperation(cCh))
                    {
                        if (operand.Value.ToString() != "")
                        {
                            break;
                        }
                        if (cCh == '(')
                        {
                            //tokenBracket.isOpened = true;
                            tokenBracket.Value = String.Format("{0}", cCh);
                            break;
                        }
                        if (cCh == ')')
                        {
                           // tokenBracket.isOpened = false;
                            tokenBracket.Value = String.Format("{0}", cCh);
                            break;
                        }
                        else
                        {
                            operation.Value = String.Format("{0}", cCh);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }

            if (operation.Value != "")
            {
                //SetOperationPriority(operation);
                return operation;
            }
            if (operand.Value != "")
            {
                
                return operand;
            }
            if (tokenBracket.Value != "")
            {
                //SetOperationPriority(tokenBracket);
                return tokenBracket;
            }
            else
            {
                throw new CalcBadSyntaxException();
            }
        }

        protected virtual bool CheckEligibleOperation(char cCh)
        {
            return cCh == '+' || cCh == '-' || cCh == '*' || cCh == '/' || cCh == '(' || cCh == ')';
        }


    }
}