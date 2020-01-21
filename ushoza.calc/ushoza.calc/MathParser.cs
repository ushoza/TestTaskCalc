using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Парсер математических выражения, понимает возведение в степень ^
    /// </summary>
    public class MathParser : DefaultParser
    {
        public override IGrammar CreateGrammar()
        {
            return new MathGrammar();
        }
    }
}