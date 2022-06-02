using System;
using System.Linq;

namespace lesson_15_Struct_CW
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            //boxing
            object o = a;

            //unboxing
            int b = (int)o;

            Console.WriteLine(o);
            Console.WriteLine(b);

            //boxing too
            Console.WriteLine($"a value is {a}");

            //because this is the same
            Console.WriteLine("a value is" + a);
            Console.WriteLine("a value is" + ((object)a).ToString());

            int x = 4;
            int y = 5;
            var vector1 = new Vector20(x, y);

            int z = x + y;
            var vector3 = Vector20.Add(vector1, vector2);

            Console.WriteLine($"vector ({vector3.X}, {vector3.Y}}");
            Console.WriteLine($"vector ({vector3.X}, {vector3.Y}}");
            Console.WriteLine(vector1 == vector2);
        }

        public struct Vector20
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Vector20(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Vector20 Add (Vector20 vector20)
            {
                //new is for not change state 
                return new Vector20(X + vector20.X, Y + vector20.Y);
            }

            public static Vector20 Add(Vector20 vector20)
            {
                return new Vector20(X + vector20.X, Y + vector20.Y);
            }

            public static Vector20 operator+ (Vector20 v1, Vector20 v2)
            {
                return new Vector20(v1.X + v2.X, v1.Y + v2.Y);
            }
        }
    }
}
