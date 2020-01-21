using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public interface ITokensValidator
    {
        void Validate(List<Token> tokens);
    }
}