using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ushoza.calc.Exceptions
{
    public class CalcBadSyntaxException : CalcException
    {
        public CalcBadSyntaxException(string msg) : base(msg)
        { }

        public CalcBadSyntaxException() : base()
        { }
    }
}
