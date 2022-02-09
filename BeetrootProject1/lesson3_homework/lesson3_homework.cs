using System;

namespace lesson3_homework
{
    class lesson3_homework
    {
        static void Main(string[] args)
        {
            //HW conitions and loops
            //09 feb 2022

            //Create a program that will start with declaration of 
            //two constants(X and Y) and will count the sum of all numbers between these constants.If they are equal then sum should be one of them
            //Example:

            //X=5
            //Y=2
            //Sum=2+3+4+5=14

            //X=10
            //Y=10
            //Sum=10

            //Extra:
            //Read values of X and Y from the console.If output is invalid - write to console Invalid input and exit the program.

            Console.WriteLine("enter A ");
            string a = Console.ReadLine();

            Console.WriteLine("enter B ");
            string b = Console.ReadLine();

            if ((int.TryParse(a, out int Adigit)) & (int.TryParse(b, out int Bdigit)))
            {
               

                if (a == b)
                {
                    Console.WriteLine("A = " + Adigit);
                    Console.WriteLine("B = " + Bdigit);
                    Console.WriteLine("SUM = " + Bdigit);
                }
                else
                {
                    int min = Math.Min(Adigit, Bdigit);
                    int max = Math.Max(Adigit, Bdigit);


                    //var 1
                    int sum = 0;

                    for (int i = min; i <= max; i++)
                    {
                        sum += i;
                    }

                    //var 2
                    //int sum = (min + max) * (max - min + 1) / 2;

                    Console.WriteLine("A = " + Adigit);
                    Console.WriteLine("B = " + Bdigit);
                    Console.WriteLine("SUM = " + sum);
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }




        }
    }
}
