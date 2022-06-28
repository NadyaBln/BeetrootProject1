using LinqLesson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace lesson_21_LINQ_CW
{
    class Program
    {
        static void Main(string[] args)
        {
            //create array from 0 to 20
            var array = Enumerable.Range(0, 20).ToArray();

            //create new array where we want to find all digits which can be divided to 2 
            var newArray = array.Where(x => x % 2 == 0).ToArray();

            //foreach to print this array
            Console.WriteLine("digists which can be divided to 2");
            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("______");

            //multiple each digit from previous array to 2 
            Console.WriteLine("multiply prev to 2");
            foreach (var item in array.Select(x => x * 2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("______");

            //use our own method from class EnumerableExtensions - OwnSelect
            //instead of inbuilded method Select 
            Console.WriteLine("OwnSelect");
            foreach (var item in array.OwnSelect(x => x * 2))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("______");

            //each item from array which can be divided by 2 -> multiply it on 3 
            IEnumerable<int> enumerable = from item in array
                                          where item % 2 == 0
                                          select item * 3;
            //print it
            Console.WriteLine("multiply on 3");
            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("______");

            //try diff methods
            array.Any(x => x == 100); //returns bool - if there is digit 100 in collection - returns true
            array.All(x => x < 100);  //check that all digits in collection = 100, if not - false 
            array.Take(3);

            //add to array 
            //each append generates new ienamerable
            //delayed execution
            array.Append(40).Append(50).Append(60);

            //or
            Console.WriteLine("append");
            foreach (var item in array.Append(40).Append(50).Append(60))
            {
                Console.WriteLine(item);
            }

            array.Append(40).Append(50).Append(60).ToList();

            //
            var balls = Enumerable.Range(0, 10).Select(x => new Ball()).ToArray();
            balls.Where(x => x.Color == Color.Green).Select(x => x.Color = Color.Blue).Take(2).ToArray();

            array.Contains(10);       //bool

            Console.WriteLine("______");
            Console.WriteLine("______");

            //____________________HOMEWORK________________________________
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            // 1 - find the youngest and the oldest persons;
            var maxAge = persons.Max(x => x.Age);
            Console.WriteLine(maxAge);
            Console.WriteLine(persons.Min(x => x.Age));


            // 2 - count number for males and females
            Console.WriteLine(persons.Count());
            Console.WriteLine($"female: {persons.Where(x => x.Gender == Gender.Female).Count()}");
            Console.WriteLine($"male: {persons.Count(x => x.Gender == Gender.Male)}");


            // 3 - find average age of all persons;
            var avgAge = persons.Sum(x => x.Age) / persons.Count();
            Console.WriteLine(avgAge);


            // 4 - find person whose age the nearest to average;
            var person1 = from i in persons
                          where i.Age == avgAge
                          select i.Name;
            foreach (var item in person1)
            {
                Console.WriteLine($"{item} is close to avg age");
            }


            // 5 - count number of active persons;
            Console.WriteLine($"active persons {persons.Count(x => x.IsActive)}");


            // 6 - find average balance of persons;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            decimal.Parse("$3,221.44", NumberStyles.Currency | NumberStyles.AllowCurrencySymbol, CultureInfo.DefaultThreadCurrentCulture);


            // 7 - count how many people with different eye colors. E.g.green - 20, brown - 30, etc.
            var greenEye = (from i in persons
                            where i.EyeColor == "green"
                            select i).Count();
            Console.WriteLine($"{greenEye} - green eyes");

            var blueEye = (from i in persons
                           where i.EyeColor == "blue"
                           select i).Count();
            Console.WriteLine($"{blueEye} - blue eyes");

            var brownEye = persons.Where(x => x.EyeColor == "brown").Count();
            Console.WriteLine($"{brownEye} - brown eyes");

            Console.WriteLine("______");
            //7- correct one
            var S1 = persons.GroupBy(x => x.EyeColor).ToDictionary(x => x.Key, x => x.Count());
            foreach (var i in S1)
            {
                Console.WriteLine(i);
            }
            var S2 = persons.GroupBy(x => x.EyeColor).ToDictionary(x => x.Key, x => x.Count()).Keys;
            foreach (var i in S2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("______");

            //print unique colors
            var distinctEyeColors = (from i in persons
                                     group i by i.EyeColor).ToList();
            foreach (var item in distinctEyeColors)
            {
                Console.WriteLine($"{item.Key} - eye color");
            }


            // 8 - count how many people has same first name
            var fName = (from i in persons
                         where i.Name.Contains("Anastasia")
                         select i.Name).Take(3);
            foreach (var item in fName)
            {
                Console.WriteLine($"{item} - same name Anastasia");
            }

            // 8 - print all names 
            var distinctNames = from i in persons
                                group i by i.Name;

            foreach (var item in distinctNames)
            {
                Console.WriteLine(item.Key);
            }


            // 9 - find out who works in same company
            //all company names 
            var companies = from i in persons
                            group i by i.Company;

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                //print name + company
                //foreach (var i in company)
                //{
                //    Console.WriteLine(i.Name);
                //}

                //Console.WriteLine();
            }


            // 10 - find out who has been registered first and last
            var firstRegi = persons.Min(x => x.Registered);
            var result = persons.FirstOrDefault(a => a.Registered == firstRegi);
            Console.WriteLine($"first regi {result.Name}");

            var lastRegi = persons.Max(x => x.Registered);
            Console.WriteLine($"last regi {lastRegi}");


            // 11 - find out what tag used most often
            //can't select only 1 value :(
            var oftenTag = (from v in persons select v).GroupBy(g => g.Tags).OrderByDescending(o => o.Count()).FirstOrDefault().Key;

            foreach (var item in oftenTag)  
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // 12 - find person who has the most number of friends
            var mostFriends1 = persons.GroupBy(x => x.Friends).OrderByDescending(o => o.Count()).FirstOrDefault();

            foreach (var item in mostFriends1)
            {
                Console.WriteLine($"person who has the most number of friends: {item.Name}");
            }
        }

        class Ball
        {
            public Color Color { get; set; }
        }

        enum Color
        {
            Green = 1,
            Blue = 2
        }
    }
}
