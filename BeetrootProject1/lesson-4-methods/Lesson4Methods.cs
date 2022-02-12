using System;

namespace lesson_4_methods
{
    class Lesson4Methods
    {
        static void Main(string[] args)
        {
            //------------------------------Classwork part-----------------------------------
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

            //will work if digit will not divid, for ex - 3
            if (TryDivideByThree(3, out int result))
            {
                Console.WriteLine($"TryDivideByThree {result}");
            }


           // Console.WriteLine(TryDivideByThree(5));

            Concat(10, 20); //30
            Concat("10", "20"); //"10, 20"
            Concat("10", "20", "30"); //"10, 20, 30"
            Concat("10", "20", "30", "40"); //4



            //---------------------------Homework part-------------------------------------------------------------

            Console.WriteLine("enter A ");
            string a = Console.ReadLine();

            Console.WriteLine("enter B ");
            string b = Console.ReadLine();

            int summa;

            if ((int.TryParse(a, out int Adigit)) && (int.TryParse(b, out int Bdigit)))
            {
                Console.WriteLine($"Value {MaxValue(Adigit, Bdigit)} is greater");
                Console.WriteLine($"Value {MinValue(Adigit, Bdigit)} is less");
                Console.WriteLine($"Result of method 'TrySumIfOdd' is {TrySumIfOdd(Adigit, Bdigit, out summa)} and Sum is {summa}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            //overload
            Console.WriteLine($"Max Value is {MaxValue(10, 20)}");
            Console.WriteLine($"Max Value is {MaxValue(101, 20, 5)}");
            Console.WriteLine($"Max Value is {MaxValue(10, 20, 5, 533)}");

            Console.WriteLine($"Min value is {MinValue(5, 533)}");
            Console.WriteLine($"Min value is {MinValue(20, 56, 533)}");
            Console.WriteLine($"Min value is {MinValue(10, 20, 52, 533)}");



            //Repeat("Ga", 5);
            //Console.WriteLine($"{Repeat("Ga", 5)}");

        }
        //-----------------------Classwork-part-------------------------------
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

            //we want to show result of dividing in console
            result = a / 3;

            //will return T / F , without part ', out int result'
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




        //--------------------Homework--------------------------------------------------
        //10 feb 2022

        //Method that will return max value among all the parameters + overload

        static int MaxValue(int a, int b)
        {

            return Math.Max(a, b);
        }

        static int MaxValue(int a, int b, int c)
        {

            int bigFromTwo = Math.Max(a, b);
            return Math.Max(bigFromTwo, c);
        }

        static int MaxValue(int a, int b, int c, int d)
        {

            int bigFromTwo = Math.Max(a, b);
            int bigFromAnotherTwo = Math.Max(c, d);
            return Math.Max(bigFromTwo, bigFromAnotherTwo);
        }


        //Method that will return min value among all the parameters + overload

        static int MinValue(int a, int b)
        {

            return Math.Min(a, b);
        }

        static int MinValue(int a, int b, int c)
        {

            int bigFromTwo = Math.Min(a, b);
            return Math.Min(bigFromTwo, c);
        }

        static int MinValue(int a, int b, int c , int d)
        {

            int bigFromTwo = Math.Min(a, b);
            int bigFromAnotherTwo = Math.Min(c, d);
            return Math.Min(bigFromTwo, bigFromAnotherTwo);

        }

        //Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd, otherwise false, sum return as out parameter
        static bool TrySumIfOdd(int a, int b, out int summa)
        {
            summa = 0;
            for (int i = a; i <= b; i++)
            {
                summa += i;
            }

            if (summa % 2 == 0) return true;
            else return false;
        }


        //Method Repeat that will accept string X and number N and return X repeated N times
        //(e.g.Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)


        //as loop
        //static void Repeat(string x, int n)
        //{
            //for (int i = 1; i<=n; i++)
            //{
            //    Console.Write(x);
            //}
        //}


        //as recursion
        //static string Repeat(string x, int n)
        //{
        //   // Console.Write(x);
        //    if (n==1) return x;
        //    return Repeat(x, n);
        //}
           
        
    }
}
