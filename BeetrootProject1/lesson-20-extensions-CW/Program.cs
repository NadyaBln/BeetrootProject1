using System;

namespace lesson_20_extensions_CW
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "My string";
            Console.WriteLine(WordCount(str1));
            Console.WriteLine(str1.WordCount());
        }
        public static int WordCount(string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

    }

    public static class StringExtentions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!' },
             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
