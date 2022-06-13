using System;
using System.Linq;
using static lesson_19_Delegates.Program;

namespace lesson_19_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter();
            counter.Increment(10, delegate (int value, int newValue)
            {
                Console.WriteLine($"{value} change it's value to {newValue}");
            });

            //lambda
            counter.Decrement(10, (old, @new) => Console.WriteLine($"{old} changed it's value to {@new}"));
            counter.OnValueChanged += CallBack;
            counter.Increment(100);

            counter.OnValueChangedDelegate = CallBack;

            counter.Decrement(100);

            counter.OnValueChangedDelegate(20, 30);

            //...

            var array = Enumerable.Range(0, 20).ToArray();
            var filteredArray = Where(array, x => x % 2 == 0);
            //foreach (var item in filteredArray)
            foreach (var item in Where(array, x => x % 2 == 0))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            //use different filtering criteria - 3
            foreach (var item in Where(array, x => x % 3 == 0))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            //5
            foreach (var item in Where(array, x => x % 5 == 0))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static U[] Select<T, U>(T[] array, Func<T, U> func);
        //public static bool Any<T>(T[] array, Func<bool, T> func);
        //public static T FirstOrDefault<T>(T[] array, Func<bool, T> func);


        //templated method
        public static T[] Where<T>(T[] array, Predicate<T> predicate)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                //if predicate returns true, we need this element
                if (predicate(array[i]))
                {
                    count++;
                }
            }

            var newArray = new T[count];
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    newArray[j++] = array[i];
                }
            }
            return newArray;
        }
        public static void CallBack(int value, int newValue)
        {
            Console.WriteLine($"{value} changed it's value to {newValue}");
        }

        public delegate void ChangedDelegate(int oldValue, int newValue);
        public class Counter
        {
            //callback - is a function
            //call method -> ChangeDelegate callback
            public void Increment(int i)
            {
                var old = i;
                var @new = ++i;

                OnValueChanged?.Invoke(old, @new);
            }

            public void Increment(int i, ChangedDelegate callback)
            {
                var old = i;
                var @new = ++i;

                callback(old, @new);
            }

            public void Decrement(int i)
            {
                var old = i;
                var @new = --i;

                OnValueChangedDelegate(old, @new);
            }

            public void Decrement(int i, ChangedDelegate callback)
            {
                var old = i;
                var @new = --i;

                callback(old, @new);
            }




            public event ChangedDelegate OnValueChanged;
            public ChangedDelegate OnValueChangedDelegate;
        }
    }
}
