using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetrootProject1.lesson_3
{
    class lesson3Homework
    {
        static void Main(string[] args)
        { //HW conitions and loops

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

            if ((int.TryParse(a, out int digit))& (int.TryParse(b, out int digita)))
            {
                Console.WriteLine(digit);
                Console.WriteLine(digita);
            }
            else
            {
                Console.WriteLine("Invalid input and exit the program");
            }

        
        }
    }
}
