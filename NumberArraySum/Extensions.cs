using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberArraySum
{
    public static class Extensions
    {
        public static int GetSum(this int[] array) => array.Sum();

        public static long GetSum(this long[] array) => array.Sum();

        public static double GetSum(this double[] array) => array.Sum();

        public static float GetSum(this float[] array) => array.Sum();

        public static decimal GetSum(this decimal[] array) => array.Sum();

        public static uint GetSum(this uint[] array)
        {
            uint sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static ulong GetSum(this ulong[] array)
        {
            ulong sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static byte GetSum(this byte[] array)
        {
            byte sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static sbyte GetSum(this sbyte[] array)
        {
            sbyte sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static short GetSum(this short[] array)
        {
            short sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }

        public static ushort GetSum(this ushort[] array)
        {
            ushort sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }
    }
}
