using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public class MathTokenOperation : DafaultTokenOperation
    {
        protected override void SetPriority()
        {
            
            if(Value == "^")
            {
                this.Priority = 20;
            }
            else
            {
                base.SetPriority();
            }
        }
    }
}