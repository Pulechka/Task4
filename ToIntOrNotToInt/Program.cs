using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToIntOrNotToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "585", "+3", "-8", "55-9", "12+3", "+123.6", "123e5e2", "e3", "1.2.3e6",
                                "+12.5+6e+3", "1r23e12","123e", "123e+12", "123e5", "12e5+3", "123-e5", "123e-12",
                                "12e", "+12.6e6", "12e6.6", "1.26e+1", "10.256e2", "10.111111111111e13", "1000e-1",  "584e-2",
                                "1000e-5", "+8.5e5", "1.1e+6","8.15e+5", "12.2e2e+5", "12.222e2", "1.e7"};
            foreach (var s in strings)
            {
                Console.WriteLine($"{s,10} - {s.IsEvenPositiveInteger()}");

            }

            const string s20 = "585";
            const string s1 = "+3";
            const string s2 = "-8";
            const string s3 = "+123.6";
            const string s4 = "123e5"; 
            const string s11 = "123e-5"; 
            const string s5 = "+8.5e5";
            const string s6 = "1.1e+6";
            const string s7 = "8.15e+5";
            const string s8 = "12.2e2e+5";
            const string s9 = "12.2122e20";
            const string s10 = "15.238e2";        
        }
    }
}