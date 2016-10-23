using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SortingUnitTask
{
    public class SortingUnit<T>
    {
        public delegate void Sorting(T[] arr);

        public static event Sorting SortCompleted;

        public static void SortArray(T[] array, Func<T, T, int> compareResult)
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
                SortCompleted?.Invoke(array);
            }
            else
                Console.WriteLine("Comparison principle is not define");
        }     
    }
}
