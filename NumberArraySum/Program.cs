using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 10,5,1,4,8};
            Console.WriteLine($"Sum of the array elements is {arr.GetSum()}");

            double[] arrDouble = new double[] { 0.4, 2.61, 0.9, 0.06};
            Console.WriteLine($"Sum of the array elements is {arrDouble.GetSum()}");
        }
    }
}
