using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    public interface IScanner
    {
        Token GetToken(string expression);
    }
}