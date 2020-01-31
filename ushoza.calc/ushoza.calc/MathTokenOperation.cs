using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public class MathTokenOperation : DefaultTokenOperation
    {
        protected override void SetPriority()
        {
            
            if(Value.ToString() == "^")
            {
                this.Priority = 30;
            }
            else
            {
                base.SetPriority();
            }
        }
    }
}