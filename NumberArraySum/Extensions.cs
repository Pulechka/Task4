using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberArraySum
{
    public static class Extensions
    {
        public static int GetSum(this int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static double GetSum(this double[] array)
        {
            double sum = 0.0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }
    }
}
