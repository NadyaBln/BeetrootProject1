using System;

namespace BeetrootProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 4;
            int y = 2;

            double resultOne = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
            Console.WriteLine("-6*x^3+5*x^2-10*x+15 = " + resultOne);

            double resultTwo = Math.Abs(x) * Math.Sin(x);
            Console.WriteLine("abs(x)*sin(x) = " + resultTwo);

            double resultThree = 2 * Math.PI * x;
            Console.WriteLine("2*pi*x = " + resultThree);

            double resultFour = Math.Max(x, y);
            Console.WriteLine("max(x, y) = " + resultFour);



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
