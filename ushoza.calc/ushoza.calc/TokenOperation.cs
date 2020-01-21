using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public class DafaultTokenOperation : Token
    {
        private object value;
        public override object Value
        {
            get { return value; }
            set 
            { 
                this.value = value;
                SetPriority();
            }

        }
        public int Priority { get;  protected set; }
        public TokenOperand Op1 { get; set; }
        public TokenOperand Op2 { get; set; }

        protected virtual void SetPriority()
        {
            switch (this.Value)
            {
                case "+":
                case "-":
                    this.Priority = 10;
                    break;
                case "*":
                case "/":
                    this.Priority = 20;
                    break;
                default:
                    break;
            }
        }

        }
}