using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ushoza.calc.Exceptions
{
    public class CalcException : Exception
    {
        public CalcException(string msg) : base(msg)
        { }
        public CalcException() : base()
        { }
    }
}
