using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Элемент скобка
    /// </summary>
    public class TokenBracket : TokenOperation
    {
        //private object val;
        //public object Value
        //{
        //    get { return val; }
        //    set
        //    {
        //        val = value;
        //        Priority = 5;
        //    }
        //}
        /// <summary>
        /// это открывающаяся скобка?
        /// </summary>
        public bool isOpened { get; set; }
    }
}