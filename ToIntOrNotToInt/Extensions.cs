using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToIntOrNotToInt
{
    public static class Extensions
    {
        public static bool IsEvenPositiveInteger(this string str)
        {
            foreach (var ch in str)
            {
                if (ch < 48 || ch > 57)
                    return false;
            }
            if ()
            return true;
        }
    }
}
