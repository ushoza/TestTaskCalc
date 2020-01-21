using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Элемент скобка
    /// </summary>
    public class TokenBracket : Token
    {
        /// <summary>
        /// это открывающаяся скобка?
        /// </summary>
        public bool isOpened { get; set; }
        
    }
}