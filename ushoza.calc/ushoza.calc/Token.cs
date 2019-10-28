using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ushoza.calc
{
    /// <summary>
    /// Общий класс для элемента математического выражения
    /// </summary>
    public class Token
    {
        public object Value { get; set; }
        

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            if (obj is Token)
            {
                Token tobj = (Token)obj;

                if (this.Value is string && tobj.Value is string)
                {

                    if (this.Value.ToString() == tobj.Value.ToString())
                    {
                        isEqual = true;
                    }
                }
                //isEqual = this.value == tobj.value ? true : false;
                else
                {

                }
            }

           return isEqual;
        }
    }
}