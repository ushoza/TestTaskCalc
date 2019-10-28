using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ushoza.calc.Exceptions;

namespace ushoza.calc
{
    /// <summary>
    /// Простейший парсер, понимает только +-/*()
    /// </summary>
    public class Parser
    {
        public virtual IScanner CreateGrammar()
        {
            return new DefaultGrammar();
        }
         
        public List<Token> Parse(string expression)
        {
            IScanner grammar = CreateGrammar();
            List<Token> listToken = new List<Token>();
            expression = expression.Replace(" ", "");
            while (expression != "")
            {
                Token forstToken = grammar.GetToken(expression);
                listToken.Add(forstToken);
                expression = expression.Remove(0, forstToken.Value.ToString().Length);

            }
            CheckSyntax(listToken);
            return listToken;

        }

        public virtual void CheckSyntax(List<Token> listToken)
        {
            for (int i = 0; i < listToken.Count - 1; i++)
            {
                Token token = listToken[i];
                Token nextToken = listToken[i + 1];
                if (token is TokenOperand && nextToken is TokenOperand)
                {
                    throw new CalcBadSyntaxException();
                }
                if (token is TokenOperation && nextToken is TokenOperation)
                {
                    if ((token.Value.ToString() != "(" && token.Value.ToString() != ")") && (nextToken.Value.ToString() != "(" && nextToken.Value.ToString() != ")"))
                    {
                        throw new CalcBadSyntaxException();
                    }

                }
                if(token is TokenOperand && nextToken is TokenBracket && (nextToken as TokenBracket).isOpened)
                    throw new CalcBadSyntaxException();
                if (listToken.Last() is TokenOperation && !(listToken.Last() is TokenBracket))
                {
                    throw new CalcBadSyntaxException();
                }
            }
        }
    }
}