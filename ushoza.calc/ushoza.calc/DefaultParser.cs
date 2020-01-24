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
                Token firstToken = grammar.GetToken(expression);
                if(firstToken.Value.ToString() == "-" && (listToken.Count == 0 || !(listToken.Last() is TokenOperand)))
                {
                    listToken.Add(new TokenOperand() { Value = "0" });
                }
                listToken.Add(firstToken);
                expression = expression.Remove(0, firstToken.Value.ToString().Length);

            }
            validator.Validate(listToken);
            return listToken;

        }

       
    }
}