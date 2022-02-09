using System;

namespace lesson_3
{
    class lesson3Classwork
    {
        static void Main(string[] args)
        {
            //int a = 5;
            //int b = 10;
            //if (a < 5)
            //{
            //    Console.WriteLine($"{a} is less than {b}");
            //}
            //else
            //{
            //    Console.WriteLine($"{a} is more than {b}");
            //}

            ////ternar
            //string s = a <= 5
            //    ? $"{a} is less than {b}"
            //    : $"{a} is more than {b}";

            //int c = a <= b
            //    ? a + b
            //    : a - b;

            //Console.WriteLine(s);


            // switch 

     

            //string message = Console.ReadLine();
            //if (int.TryParse(message, out int digit))
            //{
            //    Console.WriteLine(digit);
            //}

            //else
            //{
            //    Console.WriteLine("input is incorrect");
            //}


            

            //if (V==0)
            //{
            //    if (V == 1)
            //    {
            //        res = aa + bb;
            //    }
            //    else if (V == 2)
            //    {
            //        res = aa - bb;
            //    }
            //   else if (V == 3)
            //    {
            //        res = aa * bb;
            //    }
            //    else if (V == 4)
            //    {
            //        res = aa * bb;
            //    }
               
            //}
            //string input = Console.ReadLine();
            Console.WriteLine("enter a");
            int aa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter b");
            var bb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter V");
            var V = Convert.ToInt32(Console.ReadLine());
            int res;

            switch (V)
            {
                case 1:
                    Console.WriteLine(aa + bb);
                    break;
                case 2:
                    Console.WriteLine(aa - bb);
                    break;
                case 3:
                    Console.WriteLine(aa * bb);
                    break;
                case 4:
                    Console.WriteLine(aa / bb);
                    break;
                default:
                    Console.WriteLine("the default");
                    break;
            }




        }
    }
}
