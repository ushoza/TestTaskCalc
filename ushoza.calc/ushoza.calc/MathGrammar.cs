using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public class MathGrammar : DefaultGrammar
    {

        protected override bool CheckEligibleOperation(char cCh)
        {
            if (cCh == '^')
                return true;
            else
                return base.CheckEligibleOperation(cCh);
        }

        protected override void SetOperationPriority(TokenOperation oper)
        {
            if (oper.Value == "^")
                oper.Priority = 20;
            else
                base.SetOperationPriority(oper);    
        }
    }
}