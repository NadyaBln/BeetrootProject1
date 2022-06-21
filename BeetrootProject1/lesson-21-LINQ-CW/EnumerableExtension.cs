using LinqLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_21_LINQ_CW
{
    public static class EnumerableExtension
    {
        //create our own method select 
        public static IEnumerable<U> OwnSelect<T, U>(this IEnumerable<T> enumerable, Func<T, U> func)
        {
            foreach(var item in enumerable)
            {
                yield return func(item);
            }
        }


        //our own method where
        public static IEnumerable<T> OwnWhere<T> (this IEnumerable<T> enumerable, Func<T, bool> func)
        {
            foreach (var item in enumerable)
            {
                if (func(item))
                yield return item;
            }
        }

        public static IEnumerable<T> OwnAppend<T>(this IEnumerable<T> enumerable, T value)
        {
            foreach (var item in enumerable)
            {
                    yield return item;
            }
            yield return value;
        }
    }


    //class PersonComparer : IEqualityComparer<Person>
    //{
    //    public bool Equals(Person x, Person y)
    //    {
    //        if (x.Name == y.Name
    //                && x.Name.ToLower() == y.Name.ToLower())
    //            return true;

    //        return false;
    //    }

    //    public int GetHashCode(Person obj)
    //    {
    //        return obj.Name.GetHashCode();
    //    }
    //}


}
