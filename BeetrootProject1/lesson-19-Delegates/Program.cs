using System;
using System.Linq;
using static lesson_19_Delegates.Program;

namespace lesson_19_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //use delegate ChangedDelegate and increment 
            //new class instance 
            var counter = new Counter();

            //v1 long declaration
            //pass here 10 and delegate, method as callback
            //this is callbacke because we call some method, it does some action
            //and as a reaction to this action it calls castom code which we pass here (Cosole.WriteLine)
            counter.Increment(10, delegate (int value, int newValue)
            {
                Console.WriteLine($"{value} change it's value to {newValue}");
            });

            //v2 short delegate declaration with lambda
            //also named as Anonim function (we don't know what function is it -> (old, @new))
            counter.Decrement(10, (old, @new) => Console.WriteLine($"{old} changed it's value to {@new}"));

            //v3 instead of delegate here is class CallBack. the same logic
            counter.Increment(10, CallBack);

            //v4 also the same. as a reaction we declares Anonim method which calls method CallBack
            counter.Decrement(10, (value, newValue) => CallBack(value, newValue));

            //event
            //callback is a reaction
            counter.OnValueChanged += CallBack;
            counter.Increment(100);

            //delegate as a property
            counter.OnValueChangedDelegate = CallBack;
            counter.Decrement(100);

            //we can call delegate out of it's class
            counter.OnValueChangedDelegate(20, 30);

            //it's possible to do a chain of events / several reactions on one event
            counter.OnValueChanged += (value, newValue) => Console.WriteLine($"sum of elements {value + newValue}");
            counter.OnValueChanged -= CallBack;
            counter.Decrement(100);

            //closure - захватываем значение вне делегата, передаем его в анонимную фонкцию и  делегат
            //with anonim function
            int i = 50;
            var writer = new ConsoleWriter();
            counter.Increment(30, (value, newValue) =>
            {
                //closure 
                Console.WriteLine(i);                                                       //50
                writer.Write(i.ToString());                                                 //50
            });


            //create 1st array from 0 to 20 to use method Where
            var array = Enumerable.Range(0, 20).ToArray();

            //create second array for filtered items. there is predicate (like a condition)  x => x % 2 == 0
            var filteredArray = Where(array, x => x % 2 == 0);

            //can say here 'filteredArray' or use predicate again
            //foreach (var item in filteredArray)
            foreach (var item in Where(array, x => x % 2 == 0))
            {
                Console.Write($"{item} ");                                                      //0 2 4 6 8 10 12 14 16 18
            }
            Console.WriteLine();

            //use different filtering criteria - 3
            foreach (var item in Where(array, x => x % 3 == 0))
            {
                Console.Write($"{item} ");                                                      //0 3 6 9 12 15 18
            }
            Console.WriteLine();

            //5
            foreach (var item in Where(array, x => x % 5 == 0))
            {
                Console.Write($"{item} ");                                                      //0 5 10 15
            }
            Console.WriteLine();

            var array2 = Enumerable.Range(0, 20).ToArray();
            int from = 10;
            string to;
            var selecter = new Selecter();
            selecter.Select(array2[], (array2, to) => Console.WriteLine($"{array2}"));
        }



        //create data type delegate/ it's a method that take 2 arguments
        //this delegate method describes method which takes 2 arguments and returms void
        public delegate void ChangedDelegate(int oldValue, int newValue);

        //as an example another way to implement same logic. 
        //instead of delegate create class and pass class as argument
        public static void CallBack (int value, int newValue)
        {
            Console.WriteLine($"{value} change it's value to {newValue}");
        }

        //example of closure 
        public class ConsoleWriter
        {
            public void Write(string message)
            {
                Console.WriteLine(message);
            }
        }



        //predicate - is a standart generic delegate which takes element and returns bool
        //this method filters array by predicate
        //template method
        public static T[] Where<T>(T[] array, Predicate<T> predicate)
        {
            //go throungt array via for
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                //if predicate returns true, we need this element
                if (predicate(array[i]))
                {
                    //add 1
                    count++;
                }
            }

            //create new array
            var newArray = new T[count];

            //fill new array with elements from old one (by predicate)
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


        //have generic method who have 2 type parametrs. can convert parametr type T to type U
        //Func<T, U> func - is delegate which takes T and returns U
        //ex:
        //func<int, string>
        //var string = func(4);
        public class Selecter
        {
            public static U[] Select<T, U>(T[] array, Func<T, U> func)
            {
                var convertedArray = new U[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    convertedArray[i] = (U)Convert.ChangeType(i, typeof(U));
                    // Counter obj2 = (Counter)Convert.ChangeType(i, typeof(Counter));

                }
                
                return convertedArray;
            }
        }

        

        //public static bool Any<T>(T[] array, Func<bool, T> func);

        //returns 1st value from array which correspond by predicate. if there is no - returns default value
        //public static T FirstOrDefault<T>(T[] array, Func<bool, T> func);


        //class to use delegate ChangedDelegate
        public class Counter
        {
            //pass here delegate as argument
            //callback - is a method

            //instead on callback we can call event
            public void Increment(int i, ChangedDelegate callback)
            {
                var old = i;
                //@ because new is reserved name for C#
                var @new = ++i;

                //call method callback
                callback(old, @new);
            }

            //overload to use event OnValueChanged
            public void Increment(int i)
            {
                var old = i;
                var @new = ++i;

                //event
                OnValueChanged?.Invoke(old, @new);
                OnValueChanged?.Invoke(old, @new);
            }

            public void Decrement(int i, ChangedDelegate callback)
            {
                var old = i;
                var @new = --i;

                callback(old, @new);
            }

            //method overload to use delegate as a property OnValueChangedDelegate
            public void Decrement(int i)
            {
                var old = i;
                var @new = --i;

                OnValueChangedDelegate(old, @new);
            }

            //diff btwn delegate and event:
            //- we can call event only in that class where it's declared. delegate - can be declated out also 
            //- it's possible to do a chain of events / several reactions on one event

            //create new event
            //we can call it instead CallBack.
            //to use it let's overload method Increment
            public event ChangedDelegate OnValueChanged;

            //declare delegate as a property
            public ChangedDelegate OnValueChangedDelegate;
           
            public static void CallBack(int value, int newValue)
            {
                Console.WriteLine($"{value} changed it's value to {newValue}");
            }
        }
    }
}
