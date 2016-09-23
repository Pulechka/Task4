using System;



namespace CustomSort
{
    public delegate int CompareTwoObjects<T>(T obj1, T obj2);

    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayString = new string[] { "зима", "весна", "лето", "осень", "ёж", "модернизация", "Осень", "палата", "ток", "обвал", "кот", };
            PrintArray(arrayString);

            CompareTwoObjects<string> compareString = CompareStringByLength;
            SortArray(arrayString, compareString);
            PrintArray(arrayString);

            Console.WriteLine("---------------------------------------------------------------------");

            int[] arrayInt = new int[] { 98, 34, 8, -3, 873, -23, 54, 293, 0, -87, 395 };
            PrintArray(arrayInt);

            CompareTwoObjects<int> compareInt  = CompareInt;
            SortArray(arrayInt, compareInt);
            PrintArray(arrayInt);
        }


        private static void SortArray<T>(T[] array, CompareTwoObjects<T> compareResult)
        {
            if (compareResult != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (compareResult(array[j], array[j + 1]) > 0)
                        {
                            T temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }

            }
            else
                Console.WriteLine("Comparison principle is not define");
        }



        private static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        private static int CompareStringByLength(string str1, string str2)
        {
            if (str1.Length == str2.Length)
                return (str1[0] - str2[0]);
            else
                return (str1.Length > str2.Length) ? 1 : -1;
        }


        private static int CompareInt(int val1, int val2) => (val1 > val2) ? 1 : -1;
    }
}
