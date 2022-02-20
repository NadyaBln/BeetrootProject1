using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lesson_8_text
{
    class Lesson8text
    {
        static void Main(string[] args)
        {

            //classwork text 19 feb 2022

            var filePath = "C:/Users/Acer/source/repos/lesson8text.csv";
            var content = GetBook(filePath);

            //string sptit for several strings var 1
            string[] names = content.Split("\r\n"); //end of each string

            //build regex to find correct part. check string match to pattern
            Regex regex = new Regex(@"^(\w+);(\d+)$");

            var book = new (string name, int number)[names.Length];

            for (var index = 0; index < names.Length; index++)
            {
                var item = names[index];
                var match = regex.Match(item);
                Console.WriteLine($"item {item} match {match.Success}");

                if (match.Success)
                {
                    book[index].name = match.Groups[1].Value;
                    book[index].number = int.Parse(match.Groups[2].Value);
                }
            }

            foreach (var item in book)
            {
                Console.WriteLine($"{item.name} which phone number is {item.number}");
            }

            foreach (var item in names)
            {
                // Console.WriteLine(item);
                var match = regex.Match(item);
                Console.WriteLine($"item {item} match {match.Success}");
            }

            var random = new Random();
            book[0].number = random.Next();

            ToFile(book, filePath);

            //var 2
            // Console.WriteLine(content);
        }
        static string GetBook(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        //in this method - change phone number
        //typle data type(in mathod ToFile)
        // tylpe ex
        //int a;
        //string b;
        //(int a, string b) q;
        //q.a;
        static void ToFile((string name, int number)[] content, string filePath)
        {
            string toFileStr = string.Empty;
            foreach (var item in content)
            {
                toFileStr += $"{item.name};{item.number}\n";
            }

            File.WriteAllText(filePath, toFileStr);
        }

    }
}
