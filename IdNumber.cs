using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForLabs
{
    public class IdNumber
    {
        public int number;

        public IdNumber(int number)
        {
            this.number = number;   
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is IdNumber s)
                return this.number == s.number;    
            return false;

        }
    }
}
