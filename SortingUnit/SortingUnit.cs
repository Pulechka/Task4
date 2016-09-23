using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SortingUnitTask
{
    public delegate int CompareTwoObjects<T>(T obj1, T obj2);

    public class SortingUnit
    {
        public event EventHandler<SortResultEventArgs> SortCompleted;

        public class SortResultEventArgs : EventArgs
        {
            public string ResultDescription { get; }

            public SortResultEventArgs(string resDescription)
            {
                ResultDescription = resDescription;
            }
        }

        protected virtual void onSortComleted()
        {
            SortCompleted?.Invoke(this, new SortResultEventArgs(""));
        }
     

        public void SortArray<T>(T[] array, CompareTwoObjects<T> compareResult)
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
                onSortComleted();
            }
            else
                Console.WriteLine("Comparison principle is not define");
        }


        public void SortArrayInThread<T>(T[] array, CompareTwoObjects<T> compareResult, ref Thread th)
        {
            th = new Thread(()=>SortArray(array, compareResult));
            th.Start();
        }
    }
}
