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
        private object value;
        public override object Value
        {
            get { return value; }
            set
            {
                this.value = value;
                if (this.value.ToString() == "(")
                    isOpened = true;
                else
                    isOpened = false;
            }

        }
        /// <summary>
        /// это открывающаяся скобка?
        /// </summary>
        public bool isOpened { get; private set; }
        
    }
}