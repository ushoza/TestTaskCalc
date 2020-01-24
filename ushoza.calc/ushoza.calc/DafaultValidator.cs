using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ushoza.calc.Exceptions;

namespace ushoza.calc
{
    public class DefaultValidator : ITokensValidator
    {
        public void Validate(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count - 1; i++)
            {
                Token token = tokens[i];
                Token nextToken = tokens[i + 1];
                if (token is TokenOperand && nextToken is TokenOperand)
                {
                    throw new CalcBadSyntaxException();
                }
                if (token is DafaultTokenOperation && nextToken is DafaultTokenOperation)
                {
                    if ((token.Value.ToString() != "(" && token.Value.ToString() != ")") && (nextToken.Value.ToString() != "(" && nextToken.Value.ToString() != ")"))
                    {
                        throw new CalcBadSyntaxException();
                    }

                }
                if (token is TokenOperand && nextToken is TokenBracket && (nextToken as TokenBracket).isOpened)
                    throw new CalcBadSyntaxException();
                if (tokens.Last() is DafaultTokenOperation && !(tokens.Last() is TokenBracket))
                {
                    throw new CalcBadSyntaxException();
                }
            }
        }
    }
}