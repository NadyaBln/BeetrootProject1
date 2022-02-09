using System;

namespace lesson_4_methods
{
    class Lesson4Methods
    {
        static void Main(string[] args)
        {
            int sum = Sum(4, 5);
            //int sum = Sum('4', 5);
            //'4' is os as char is int inside
            Console.WriteLine(sum);


            Console.WriteLine(Sum(10,20));       //30
            Console.WriteLine(Sum(10,20, true)); //30
            Console.WriteLine(Sum(10,20, false)); //-10


            Console.WriteLine(SumNumbers(20,10)); //145

            int i = 10;
            i = Increment(i);
            Console.WriteLine(i); //11


            int c = 10;
            IncrementTwo(ref c);
            IncrementTwo(ref c);
            Console.WriteLine(i); //11


            if (TryDivideByThree(i, out int result))
            {
                Console.WriteLine(result);
            }


            Concat(10, 20); //30
            Concat("10", "20"); //"10, 20"
            Concat("10", "20", "30"); //"10, 20, 30"
            Concat("10", "20", "30", "40"); //4
        }

        static void Concat (int a, int b)
        {
            Console.WriteLine(a + b);

        }
        static void Concat(string a, string b)
        {
            Console.WriteLine($"{a}, {b}");

        }
        static void Concat(string a, string b, string c)
        {
            Console.WriteLine($"{a}, {b}, {c}");

        }
        static void Concat (params string [] strings)
        {
            Console.WriteLine(strings.Length);
        }



        static int Sum (int a, int b, bool r = true)
        {
            //return a + b;
            if (r == true) return a + b;
            else return a - b;
        }



        //сумма чисел между числами (как в дз)
        static int SumNumbers (int a, int b)
        {
            int sum = 0;
            for (int i =a; i <= b; i++)
            {
                sum += i;
            }
            return sum;
        }




        static int Increment (int i)
        {
            i++;
            return i;
        }
        static int IncrementTwo(ref int c)
        {
            c++;
            return c;
        }



        static bool TryDivideByThree(int a, out int result)
        {
            //if divide - true 
            //not divide - false

            result = a / 3;
            return a % 3 == 0;
           
        }




        static int Factorial (int value)
        {

            //as recursion
            if (value == 1) return value;
            return value * Factorial(value - 1);

            //as loop
                //int a = 0;
                //for (int i = 0; i < value; i++)
                //{
                //    a = i * (i + 1);

                //}
                //Console.WriteLine(a);

        }

    }
}
