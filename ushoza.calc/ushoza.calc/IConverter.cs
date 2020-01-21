using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Интерфейс конвертера списка Tokens в вид подходящий для расчета
    /// </summary>
    public interface IConverter
    {
        Queue<Token> Convert(List<Token> source);
    }
}