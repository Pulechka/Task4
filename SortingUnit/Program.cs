using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SortingUnitTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SortingUnit su = new SortingUnit();
            su.SortCompleted += GetSortResult;

            string[] arrayString = new string[] { "зима", "весна", "лето", "осень", "ёж", "модернизация", "Осень", "палата", "ток", "обвал", "кот", };
            PrintArray(arrayString);

            CompareTwoObjects<string> compareString = CompareStringByLength;
            su.SortArray(arrayString, compareString);
            PrintArray(arrayString);

            Console.WriteLine("---------------------------------------------------------------------");

            int[] arrayInt = new int[] { 98, 34, 8, -3, 873, -23, 54, 293, 0, -87, 395, };
            PrintArray(arrayInt);

            CompareTwoObjects<int> compareInt = CompareInt;
            Thread th = null;
            su.SortArrayInThread(arrayInt, compareInt, ref th);
            PrintArray(arrayInt);
            th.Join();
            PrintArray(arrayInt);
        }



        private static int CompareStringByLength(string str1, string str2)
        {
            if (str1.Length == str2.Length)
                return (str1[0] - str2[0]);
            else
                return (str1.Length > str2.Length) ? 1 : -1;
        }


        private static int CompareInt(int val1, int val2) => (val1 > val2) ? 1 : -1;


        private static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void GetSortResult(object sender, EventArgs e)
        {
            Console.WriteLine($"Sort array is completed {sender}");
        }
    }
}
