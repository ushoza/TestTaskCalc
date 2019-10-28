using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public class TokenOperation : Token
    {
        //private object val;
        //public object Value
        //{
        //    get { return val; }
        //    set
        //    {
        //        val = value;

        //    }
        //}
        public int Priority { get;  set; }
        public TokenOperand Op1 { get; set; }
        public TokenOperand Op2 { get; set; }
        
    }
}