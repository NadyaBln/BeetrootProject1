using System;
using System.Linq;

namespace lesson_16_Gererics_CW
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            //create random array with 10 elements
            var array = Enumerable.Range(0, 10).Select(_ => random.Next(100)).ToArray();
            //print this array
            foreach (var item in array)
            {
                Console.WriteLine(item);                                                //some array 10 elements
            }

            Sort(array);
            foreach (var item in array)
            {
                Console.WriteLine(item);                                                //swap v1 -> in case we don't use 'ref' - same, not sorted array
            }

            //HOMEWORK PART
            Person Person1 = new Person("Ann", "Ran", "30");
            Person Person2 = new Person("Bnn", "Ran", "31");
            Person Person3 = new Person("Dnn", "Ran", "32");
            Person Person4 = new Person("Cnn", "Ran", "33");

            object[] PersonArray1 = new[] { Person1, Person2, Person3, Person4 };
            
        }

        //swap v1 and v2
        //ref - because we work with memory cell. if we will not put 'ref' - array will not be sorted
        //private static void Swap(ref int a, ref int b)
        //{
        //    int temp = a;
        //    a = b;
        //    b = temp;
        //}

        //same method but for strings
        //private static void Swap(ref string a, ref string b)
        //{
        //    string temp = a;
        //    a = b;
        //    b = temp;
        //}


        //make new method to sort all datatypes. instead 2 previous

        //there is 1st attempt - not good 
        //also not so good because of boxing unboxing
        //private static void Swap(ref object a, ref object b)
        //{
        //    var temp = a;
        //    a = b;
        //    b = temp;
        //}


        //GOOD ONE! Generic. good becausewe don't choose certain data type
        //insead of <T> could be anythisng (<TYPE>)
        // <T> - data type which we don't define, it unknown at moment of method calling
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        //replace it with Generic method sort
        ////bubble sorting
        ////now, using Generics, we can replace both methods: Sort(int[] array) and Sort(string[] array) with Generic one (below)
        //private static void Sort(int[] array)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        for (int j = 0; j < array.Length - 1; j++)
        //        {
        //            //data type Int (and string) implements interface IComparable
        //            IComparable<int> item1 = array[j];

        //            //IComparable have method CompareTo, which cat Compare 1 int to another
        //            if (item1.CompareTo(array[j + 1]) == -1) 
        //            {

        //            //if (array[j] < array[j + 1])
        //            //{
        //                //swap v1
        //                //when we don't have Swap method 
        //                //var temp = array[j];
        //                //array[j] = array[j + 1];
        //                //array[j + 1] = temp;

        //                //swap v2
        //                //in case we have 2 methods Swap for each data types
        //                //Swap(ref array[j], ref array[j + 1]);

        //                //swap v3
        //                //not good with Object because of boxing (and memory)
        //                //object o1 = array[j];
        //                //object o2 = array[j+1];
        //                //Swap(ref o1, ref o2);
        //                //array[j] = (int)o1;
        //                //array[j+1] = (int)o2;

        //                //swap with Generics
        //                //call it with int
        //                Swap<int>(ref array[j], ref array[j + 1]);
        //            }
        //        }
        //    }
        //}

        ////Sort method Overload, but with string
        //private static void Sort(string[] array)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        for (int j = 0; j < array.Length - 1; j++)
        //        {
        //            //data type String (and Int also) implements interface IComparable
        //            IComparable<string> item1 = array[j];

        //            //IComparable have method CompareTo, which cat Compare 1 string to another
        //            if (item1.CompareTo(array[j + 1]) == -1)
        //            {
        //                Swap<string>(ref array[j], ref array[j + 1]);
        //                //return values:
        //                //-1 - less
        //                //0 - equals
        //                //1 - more
        //            }

        //            //use Interface IComparable instea of this one
        //            //if (string.Compare(array[j], array[j + 1]) == -1)
        //            //{
        //            //swap v1
        //            //var temp = array[j];
        //            //array[j] = array[j + 1];
        //            //array[j + 1] = temp;

        //            //swap with Generics
        //            //define data type when we call a method:
        //            Swap<string>(ref array[j], ref[j + 1]);
        //        }
        //    }
        //}


        //generic method instead of INT and String methods: Sort(int[] array) and Sort(string[] array)

        //we can clarify how can <T> be with 'where T : IComparable<T>'
        private static void Sort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    //we can't convert array item to IComparable data type because <T>
                    //doesn't sure that it will be able to convert type we could pass there.
                    IComparable<T> item1 = array[j];

                    if (item1.CompareTo(array[j + 1]) == -1)
                    {
                        Swap<T>(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
}
