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
        public delegate bool MatchConndition<T>(T item);

        static void Main(string[] args)
        {
            List<int> arr1 = new List<int> { 0,-9,54,7,-4,8,-34,7,-54,-4,76,34};

            List<int> positive1 = FindAllPositive(arr1);
            Console.WriteLine("All positive (method):");
            foreach (var item in positive1)         
            {
                Console.Write(item+" ");
            }
            Console.WriteLine("\n");


            List<int> negative2 = FindByCondition(arr1, new MatchConndition<int>(IsNegative));
            Console.WriteLine("All positive (delegate instance):");
            foreach (var item in negative2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            List<int> negativeAnonym3 = FindByCondition(arr1, delegate(int item) { return item > 0; });
            Console.WriteLine("All positive (anonym):");
            foreach (var item in negativeAnonym3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            List<int> negativeAnonym4 = FindByCondition(arr1, (x) => (x > 0));
            Console.WriteLine("All positive (lymbda):");
            foreach (var item in negativeAnonym4)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");



            List<string> arr2 = new List<string> { "зима", "Весна", "лето", "осень", "Ёж", "модернизация", "палата", "Ток", "обвал", "кот", };

            List<string> withCapital = FindByCondition(arr2, new MatchConndition<string>(IsWithCapital));
            Console.WriteLine("Words with capital first letter:");
            foreach (var item in withCapital)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n-------------------------------------------------------------------------");




            List<int> inputData = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 500; i++)
            {
                inputData.Add(r.Next(-100, 100));
            }
            List<int> result;

            
            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < 20; i++)
            {
                watch.Start();
                result = FindAllPositive(inputData);
                watch.Stop();
                Console.WriteLine(watch.Elapsed);
                watch.Reset();
            }
        }


        public static List<int> FindAllPositive(List<int> inputArray) 
        {
            List<int> result = new List<int>();
            foreach (var item in inputArray)
            {
                if (item > 0)
                {
                    result.Add(item);
                }
            }
            return result;
        }


        public static List<T> FindByCondition<T>(List<T> inputArray, MatchConndition<T> isMatchCondition)
        {
            List<T> result = new List<T>();
            foreach (var item in inputArray)
            {
                if (isMatchCondition(item))
                {
                    result.Add(item);
                }
            } 
            return result;
        }

        public static bool IsNegative(int item)
        {
            return item > 0;
        }

        public static bool IsWithCapital(string item)
        {
            return char.IsUpper(item[0]);
        }
    }
}
