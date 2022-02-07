using System;

namespace lesson_data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            int b = 3;
            byte av = 250;
            short c = 300;
            ushort d = 2345;

            int i = 5;
            //адитивные
            int res = ++i + i++;
            Console.WriteLine(res);
            Console.WriteLine(-i);
            //12

            bool isTrue = false;
            Console.WriteLine(!isTrue);
            //true

            //multiplicative
            Console.WriteLine(a * b);
            Console.WriteLine(6 / 4);
            Console.WriteLine(6 % 4);

            //смещения
            Console.WriteLine(a << b);
            //2 - 00000010 => 00010000 = 16

            double aD = 3.4;
            double bD = 5.6;

            Console.WriteLine("result var 1 " + (aD * bD - Math.Sqrt(100) / 5));
            Console.WriteLine("result var 2 " + (aD * bD - Math.Sqrt(100) / 5).ToString());
            Console.WriteLine($"result var 3 {aD * bD - Math.Sqrt(100) / 5}");
            //17.04

            int aA = 4;
            int bB = 10;

            Console.WriteLine(aA < bB); //true
            Console.WriteLine(aA > bB); //false
            Console.WriteLine(!(aA > bB)); //true
            Console.WriteLine(!(aA == bB)); //true

            bool aBool = false;
            bool bBool = true;
            Console.WriteLine(aBool | bBool); //true
            Console.WriteLine(aBool || bBool); //true

          //  Console.WriteLine(aA || bB); //true


            var now = DateTime.Now;

            Console.WriteLine(now);
            Console.WriteLine(now.Year - 1);
            //prev year

            var yest = now.AddDays(-1);
            Console.WriteLine(yest);








            //
            DateTime dateToday = DateTime.Today;
            // Console.WriteLine("Date today - " + dateToday);

            DateTime lastDayOf2022 = new DateTime(2022, 12, 31);
            // Console.WriteLine("Last day of 2022 - " + lastDayOf2022);

            DateTime firstDayOf2022 = new DateTime(2022, 01, 01);
            // Console.WriteLine("First day of 2022 - " + firstDayOf2022);

            double leftToNewYear = (lastDayOf2022 - dateToday).TotalDays;
            Console.WriteLine("days left to New Year - " + leftToNewYear);

            double passedFromNewYear = (dateToday - firstDayOf2022).TotalDays;
            Console.WriteLine("days passed from New Year - " + passedFromNewYear);



        }
    }
}
