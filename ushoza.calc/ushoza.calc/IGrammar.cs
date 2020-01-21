using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Интерфейс парсера
    /// </summary>
    public interface IGrammar
    {
        Token GetToken(string expression);
    }
}