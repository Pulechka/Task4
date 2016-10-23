using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISeekYou
{
    class Program
    {
        public delegate bool MatchConndition(int num);

        static void Main(string[] args)
        {
            int[] arr1 = CreateNumericArray(1000);
            int[] arr2 = new int[1000];
            int[] arr3 = new int[1000];
            int[] arr4 = new int[1000];
            int[] arr5 = new int[1000];

            arr1.CopyTo(arr2, 0);
            arr1.CopyTo(arr3, 0);
            arr1.CopyTo(arr4, 0);
            arr1.CopyTo(arr5, 0);


            int watchCount = 20;
            GetWatchResultByMethod(arr1, watchCount);
            GetWatchResultByDelgate(arr2, watchCount);
            GetWatchResultByAnonymousMethod(arr3, watchCount);
            GetWatchResultByLymbda(arr4, watchCount);
            GetWatchResultByLinq(arr5, watchCount);
            Console.WriteLine();
        }


        public static void GetWatchResultByMethod(int[] inputData, int watchCount)
        {
            int[] result;
            Stopwatch watch = new Stopwatch();
            List<TimeSpan> watchResults = new List<TimeSpan>();

            for (int i = 0; i < watchCount; i++)
            {
                watch.Restart();
                result = FindAllPositive(inputData);
                watch.Stop();
                watchResults.Add(watch.Elapsed);
                watchResults = watchResults.OrderBy(w => w).ToList();
            }
            Console.WriteLine($"By method:\t\t\t\t{watchResults[watchCount/2]}");
        }

        public static void GetWatchResultByDelgate(int[] inputData, int watchCount)
        {
            int[] result;
            Stopwatch watch = new Stopwatch();
            List<TimeSpan> watchResults = new List<TimeSpan>();

            for (int i = 0; i < watchCount; i++)
            {
                watch.Restart();
                result = FindByCondition(inputData, new MatchConndition(IsNegative));
                watch.Stop();
                watchResults.Add(watch.Elapsed);
                watchResults = watchResults.OrderBy(w => w).ToList();
            }
            Console.WriteLine($"By method with delegate:\t\t{watchResults[watchCount / 2]}");
        }

        public static void GetWatchResultByAnonymousMethod(int[] inputData, int watchCount)
        {
            int[] result;
            Stopwatch watch = new Stopwatch();
            List<TimeSpan> watchResults = new List<TimeSpan>();

            for (int i = 0; i < watchCount; i++)
            {
                watch.Restart();
                result = FindByCondition(inputData, delegate(int num) { return num > 0; });
                watch.Stop();
                watchResults.Add(watch.Elapsed);
                watchResults = watchResults.OrderBy(w => w).ToList();
                watch.Reset();
            }
            Console.WriteLine($"By method with anonymous method:\t{watchResults[watchCount / 2]}");
        }


        public static void GetWatchResultByLymbda(int[] inputData, int watchCount)
        {
            int[] result;
            Stopwatch watch = new Stopwatch();
            List<TimeSpan> watchResults = new List<TimeSpan>();

            for (int i = 0; i < watchCount; i++)
            {
                watch.Restart();
                result = FindByCondition(inputData, n=>n>0);
                watch.Stop();
                watchResults.Add(watch.Elapsed);
                watchResults = watchResults.OrderBy(w => w).ToList();
            }
            Console.WriteLine($"By method with lymbda:\t\t\t{watchResults[watchCount / 2]}");
        }

        public static void GetWatchResultByLinq(int[] inputData, int watchCount)
        {
            List<int> result = null;
            Stopwatch watch = new Stopwatch();
            List<TimeSpan> watchResults = new List<TimeSpan>();

            for (int i = 0; i < watchCount; i++)
            {
                watch.Restart();
                result = inputData.Where(n => n > 0).ToList();
                watch.Stop();
                watchResults.Add(watch.Elapsed);
                watchResults = watchResults.OrderBy(w => w).ToList();
            }
            Console.WriteLine($"By method with Linq:\t\t\t{watchResults[watchCount / 2]}");
        }

        public static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }

        public static int[] CreateNumericArray(int count)
        {
            int[] arr = new int[count];
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                arr[i] = r.Next(-100, 100);
            }
            return arr;
        }



        public static int[] FindAllPositive(int[] inputArray) 
        {
            List<int> result = new List<int>();
            foreach (var item in inputArray)
            {
                if (item > 0)
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }


        public static int[] FindByCondition(int[] inputArray, MatchConndition isMatchCondition)
        {
            List<int> result = new List<int>();
            if (isMatchCondition != null)
            {
                foreach (var item in inputArray)
                {
                    if (isMatchCondition(item))
                    {
                        result.Add(item);
                    }
                }
            }
            return result.ToArray();
        }

        public static bool IsNegative(int item)
        {
            return item > 0;
        }
    }
}
