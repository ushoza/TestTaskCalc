using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Интерфейс парсера
    /// </summary>
    public interface IScanner
    {
        Token GetToken(string expression);
    }
}