using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public class MathParser : Parser
    {
        public override IScanner CreateGrammar()
        {
            return new MathGrammar();
        }
    }
}