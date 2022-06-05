using System;
using System.Linq;

namespace lesson_16_Gererics_CW
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var array = Enumerable.Range(0,10).Select(_ =>random.)
        }

        //bubble sorting
        private static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        //swap v1
                        //when we don't have Swap method 
                        //var temp = array[j];
                        //array[j] = array[j + 1];
                        //array[j + 1] = temp;

                        //swap v2
                        //in case we have 2 methods Swap for each data types
                        //Swap(ref array[j], ref array[j + 1]);

                        //swap v3
                        //not good with Object
                        //object o1 = array[j];
                        //object o2 = array[j+1];
                        //Swap(ref o1, ref o2);
                        //array[j] = (int)o1;
                        //array[j+1] = (int)o2;

                        Swap<int>(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        //swap v1 and v2
        //private static void Swap(ref int a, ref int b)
        //{
        //    int temp = a;
        //    a = b;
        //    b = temp;
        //}

        //private static void Swap(ref string a, ref string b)
        //{
        //    string temp = a;
        //    a = b;
        //    b = temp;
        //}

        //make new method to sort all datatypes. instead of 2 previous

        //also not so good because of boxing unboxing
        //private static void Swap(ref object a, ref object b)
        //{
        //    var temp = a;
        //    a = b;
        //    b = temp;
        //}

        //good one. Generic
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        private static void Sort(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    //if (string.Compare(array[j], array[j + 1]) == -1)
                    //{
                    //    ////swap
                    //    //var temp = array[j];
                    //    //array[j] = array[j + 1];
                    //    //array[j + 1] = temp;

                        IComparable<string> item1 = array[j];

                        if (item1.CompareTo(array[j + 1]) == -1)
                        {
                            Swap<string>(ref array[j], ref array[j + 1]);
                        }
                    //}
                }
            }
        }
    }
}
