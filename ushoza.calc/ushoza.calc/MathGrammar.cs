using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Грамматика для математиечского парсера
    /// </summary>
    public class MathGrammar : DefaultGrammar
    {

        protected override bool CheckEligibleOperation(char cCh)
        {
            if (cCh == '^')
                return true;
            else
                return base.CheckEligibleOperation(cCh);
        }

       
    }
}