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
            SortingUnit<int>.SortCompleted += ShowSortResult;
            SortingUnit<string>.SortCompleted += ShowSortResult;

            int[] intArray = CreateNumericArray(100);
            Console.WriteLine("Input array:");
            PrintArray(intArray);
            Console.WriteLine();
            SortArrayInThread(intArray, CompareInt);

            string[] strArray = new string[] { "зима", "весна", "лето", "осень", "ёж", "модернизация", "Осень", "палата", "ток", "обвал", "кот", };
            Console.WriteLine("Input array:");
            PrintArray(strArray);
            Console.WriteLine();
            SortArrayInThread(strArray, CompareStringByLength);
        }

        public static void SortArrayInThread<T>(T[] array, Func<T, T, int> compareResult)
        {
            Thread th = new Thread(() => SortingUnit<T>.SortArray(array, compareResult));
            th.Start();
        }

        public static void ShowSortResult<T>(T[] array)
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"Sorting of array is completed");
            PrintArray(array);
            Console.WriteLine(new string('-', 100));
        }

        private static int CompareInt(int val1, int val2) => (val1 > val2) ? 1 : -1;

        private static int CompareStringByLength(string str1, string str2)
        {
            if (str1.Length == str2.Length)
                return (str1[0] - str2[0]);
            else
                return str1.Length - str2.Length;
        }


        private static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        private static int[] CreateNumericArray(int length)
        {
            int[] arr = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = rnd.Next(-1000, 1000);
            }
            return arr;
        }
    }
}
