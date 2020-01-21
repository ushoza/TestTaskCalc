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
    public class DefaultParser
    {
        public virtual IGrammar CreateGrammar()
        {
            return new DefaultGrammar();
        }

        public virtual ITokensValidator CreateValidator()
        {
            return new DafaultValidator();
        }
         
        public List<Token> Parse(string expression)
        {
            IGrammar grammar = CreateGrammar();
            List<Token> listToken = new List<Token>();
            expression = expression.Replace(" ", "");
            while (expression != "")
            {
                Token forstToken = grammar.GetToken(expression);
                listToken.Add(forstToken);
                expression = expression.Remove(0, forstToken.Value.ToString().Length);

            }
            ITokensValidator validator = CreateValidator();
            validator.Validate(listToken);
            return listToken;

        }

       
    }
}