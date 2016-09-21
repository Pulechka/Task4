using System;

public delegate int CompareTwoObjects<T>(T obj1, T obj2);

namespace CustomSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayString = new string[] { "зима","весна","лето","осень","ёж","модернизация","Осень","палата","ток","обвал","кот",};
            ArrayWorker.PrintArray<string>(arrayString);

            CompareTwoObjects<string> compareString = CompareStringByLength;
            ArrayWorker.SortArray<string>(arrayString, compareString);
            ArrayWorker.PrintArray<string>(arrayString);

            Console.WriteLine("---------------------------------------------------------------------");

            int[] arrayInt = new int[] { 98, 34,8,-3, 873, -23, 54, 293, 0, -87, 395};
            ArrayWorker.PrintArray<int>(arrayInt);

            CompareTwoObjects<int> compareInt = null;// = CompareInt;
            ArrayWorker.SortArray<int>(arrayInt, compareInt);
            ArrayWorker.PrintArray<int>(arrayInt);
        }


        static int CompareStringByLength(string str1, string str2)
        {
            if (str1.Length > str2.Length)
                return 1;
            else if (str1.Length < str2.Length)
                return -1;
            else
            {
                return (str1[0] - str2[0]);
            }
        }


        static int CompareInt(int val1, int val2)
        {
            if (val1 > val2)
                return 1;
            else return -1;
        }
    }
}
