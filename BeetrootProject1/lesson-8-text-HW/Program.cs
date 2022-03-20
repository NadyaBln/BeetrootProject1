using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace lesson_8_text_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------homework---------------------------------------------------------
            //Provide ability to search in phone book by any criteria(first / last name or phone number)

            var hwFilePath = "C:/Users/Acer/source/repos/phoneBookForHW.csv";
            Regex regexHW = new Regex(@"^(\w+);(\w+);(\d+)$");
            var contentHW = GetBook(hwFilePath);
            string[] personStringHW = contentHW.Split("\r\n"); //end of each string

            //create new data type by tulple
            var phoneBookHW = new (string name, string surname, int number)[personStringHW.Length];

            Console.WriteLine("Enter name / surname / phone or it part");
            string userInput = Console.ReadLine();



            //check that content in file matches with template
            for (var index = 0; index < personStringHW.Length; index++)
            {
                var item = personStringHW[index];
                var match = regexHW.Match(item);

                if (match.Success)
                {
                    phoneBookHW[index].name = match.Groups[1].Value;
                    phoneBookHW[index].surname = match.Groups[2].Value;
                    phoneBookHW[index].number = int.Parse(match.Groups[3].Value);
                }
            }

            GetSearchedString(userInput, phoneBookHW);

            //change here OrderBy.
            Sort(phoneBookHW, OrderBy.FirstName);
            Sort(phoneBookHW, OrderBy.LastName);
            Sort(phoneBookHW, OrderBy.PhoneNumber);
        }

        static string GetBook(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        static bool IsContain(string value, string subString)
        {
            return value.ToLower().Contains(subString);
        }

        //main method to find string 
        static void GetSearchedString(string userInput, (string name, string surname, int number)[] phoneBookHW)
        {
            //the advantage with lists being, you don't need to know the array size when instantiating the list
            List<(string name, string surname, int number)> result = new();
            string input = userInput.ToLower();

            foreach (var item in phoneBookHW)
            {
                string phone = Convert.ToString(item.number);

                if (IsContain(item.name, input) || IsContain(item.surname, input) || IsContain(phone, input))
                {
                    result.Add(item);
                }
            }
            if (result.Count > 0)
            {
                Console.WriteLine($"Search results: ");
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.name} {item.surname} {item.number}");
                }
            }
            else
            {
                Console.WriteLine("not found");
            }
        }

        //Update phone number program that will store rows in alphabetical order
        //(order by last name, first name and then phone number)

        enum OrderBy
        {
            LastName,
            FirstName,
            PhoneNumber
        }

        static void Sort((string name, string surname, int number)[] content, OrderBy type)
        {
            switch (type)
            {
                case OrderBy.LastName:
                    SortingByLN(content);
                    break;

                case OrderBy.FirstName:
                    SortingByFN(content);
                    break;

                case OrderBy.PhoneNumber:
                    SortingByPN(content);
                    break;
            }

            static void SortingByFN((string name, string surname, int number)[] content)
            {
                Console.WriteLine($"Sorted by {OrderBy.FirstName}");
                var list = content.OrderBy(t => t.name).ToList();
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.name} {item.surname} {item.number}");
                }
            }

            static void SortingByLN((string name, string surname, int number)[] content)
            {
                Console.WriteLine($"Sorted by {OrderBy.LastName}");
                var list = content.OrderBy(t => t.surname);
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.name} {item.surname} {item.number}");
                }
            }

            static void SortingByPN((string name, string surname, int number)[] content)
            {
                Console.WriteLine($"Sorted by {OrderBy.PhoneNumber}");
                var list = content.OrderBy(t => t.number);
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.name} {item.surname} {item.number}");
                }
            }
        }
    }
}
