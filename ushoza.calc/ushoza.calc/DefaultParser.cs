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
        //public virtual IGrammar CreateGrammar()
        //{
        //    return new DefaultGrammar();
        //}

        //public virtual ITokensValidator CreateValidator()
        //{
        //    return new DafaultValidator();
        //}
        private IGrammar grammar;
        private ITokensValidator validator;


        public DefaultParser(IGrammar grammar, ITokensValidator validator)
        {
            this.grammar = grammar;
            this.validator = validator;
        }
        public List<Token> Parse(string expression)
        {
            
            List<Token> listToken = new List<Token>();
            expression = expression.Replace(" ", "");
            while (expression != "")
            {
                Token forstToken = grammar.GetToken(expression);
                listToken.Add(forstToken);
                expression = expression.Remove(0, forstToken.Value.ToString().Length);

            }
            validator.Validate(listToken);
            return listToken;

        }

       
    }
}