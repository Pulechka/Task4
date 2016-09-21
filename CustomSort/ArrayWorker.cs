using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSort
{
    public static class ArrayWorker
    { 

        public static void SortArray<T>(T[] array, CompareTwoObjects<T> compare)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length-1; j++)
                {
                    if (compare(array[j],array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }


        public static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
