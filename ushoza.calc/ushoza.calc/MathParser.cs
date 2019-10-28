using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Парсер математических выражения, понимает возведение в степень ^
    /// </summary>
    public class MathParser : Parser
    {
        public override IScanner CreateGrammar()
        {
            return new MathGrammar();
        }
    }
}