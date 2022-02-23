using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lesson_8_text
{
    class Lesson8text
    {
        static void Main(string[] args)
        {

            ////classwork text 19 feb 2022

            //var filePath = "C:/Users/Acer/source/repos/lesson8text.csv";
            //var content = GetBook(filePath);

            ////string sptit for several strings var 1
            //string[] names = content.Split("\n"); //end of each string

            ////build regex to find correct part. check string match to pattern
            //Regex regex = new Regex(@"^(\w+);(\d+)$");

            ////tuple. array with length of one string
            //var book = new (string name, int number)[names.Length];

            //for (var index = 0; index < names.Length-1; index++)
            //{
            //    //check that each string in files matches with template 
            //    var item = names[index];
            //    var match = regex.Match(item);
            //    Console.WriteLine($"item {item} match {match.Success}");

            //    if (match.Success)
            //    {
            //        book[index].name = match.Groups[1].Value;
            //        book[index].number = int.Parse(match.Groups[2].Value);
            //    }
            //}

            //foreach (var item in book)
            //{
            //    Console.WriteLine($"{item.name} which phone number is {item.number}");
            //}

            //foreach (var item in names)
            //{
            //    // Console.WriteLine(item);
            //    var match = regex.Match(item);
            //    Console.WriteLine($"item {item} match {match.Success}");
            //}

            //var random = new Random();
            //book[0].number = random.Next();

            ////ToFile(book, filePath);

            ////var 2
            //// Console.WriteLine(content);





            //---------homework---------------------------------------------------------
            //Provide ability to search in phone book by any criteria(first / last name or phone number)

            var hwFilePath = "C:/Users/Acer/source/repos/phoneBookForHW.csv";
            Regex regexHW = new Regex(@"^(\w+);(\w+);(\d+)$");
            var contentHW = GetBook(hwFilePath);
            string[] personStringHW = contentHW.Split("\r\n"); //end of each string
            
            //create new data type by tulple
            var phoneBookHW = new (string name, string surname, int number)[personStringHW.Length];

            Console.WriteLine("Enter name / suraname / phone or it part");
            string userImput = Console.ReadLine();

            //int.TryParse(userImput, out int userImputInt);

            //check that content in file matches with template
            for (var index = 0; index < personStringHW.Length; index++)
            {
                var item = personStringHW[index];
                var match = regexHW.Match(item);
            //   Console.WriteLine($"item {item} match {match.Success}");

                if (match.Success)
                {
                    phoneBookHW[index].name = match.Groups[1].Value;
                    phoneBookHW[index].surname = match.Groups[2].Value;
                    phoneBookHW[index].number = int.Parse(match.Groups[3].Value);
                }

                //if (userImput.Contains(phoneBookHW[index].name) | userImput.Contains(phoneBookHW[index].surname))
                //{
                //    Console.WriteLine($"Search result: {item}");
                //}
                
                //Console.WriteLine("Nothing found");
            }
            if (userImput.Contains(item.name))

          





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
        //static void ToFile((string name, int number)[] content, string filePath)
        //{
        //    string toFileStr = string.Empty;
        //    foreach (var item in content)
        //    {
        //        toFileStr += $"{item.name};{item.number}\n";
        //    }

        //    File.WriteAllText(filePath, toFileStr);
        //}


        //---------homework--------------------------------------------------------------
        //enum SearchBy
        //{
        //    Name,
        //    Surname,
        //    Phone
        //}

        //static string SearchByFieldInPhoneBook(string path, SearchBy field)
        //{
        //    switch (field)
        //    {
        //        case SearchBy.Name:
        //            break;
        //        case SearchBy.Surname:
        //            break;
        //        case SearchBy.Phone:
        //            break;
        //    }
        //}

        //static string SearchByField(string userImput)
        //{
        //    if (userImput == )
        //}

        //static string SearchByField(string surnameOfUser, Regex regex)
        //{

        //}

        //static string SearchByField(int phone, Regex regex)
        //{

        //}
    }
}
