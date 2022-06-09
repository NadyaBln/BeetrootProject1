using System;
using System.Linq;

namespace lesson_15_Struct_CW
{
    class Program
    {
        static void Main(string[] args)
        {

            //boxing ex
            int a = 100;
            object o = a;

            //unboxing ex
            int b = (int)o;

            //boxing also
            Console.WriteLine($"a value is {a.ToString()}");                 // a value is 100
            Console.WriteLine("a value is " + ((object)a).ToString());       // a value is 100

            //Enumerable - Исчисляемый / перечислимый
            //create array from 1 to 3
            int[] array = Enumerable.Range(1, 3).ToArray();

            //make multiplayer table. not g
            foreach (var i in array)
            {
                foreach (var j in array)
                {
                    Console.Write($"{(i * j).ToString()}     ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(o);                                               //100
            Console.WriteLine(b);                                               //100

            int x = 4;
            int y = 5;

            //strukt always have default constructor even we call another one with paramethers. in class we should create it manually
            var vector1_0 = new Vector2D();
            var vector1 = new Vector2D(x, y);
            var vector2 = new Vector2D(x, y);

            int z = x + y;
            var vector3 = Vector2D.Add(vector1, vector2);
            var vector4 = vector1 + vector2;

            Console.WriteLine($"vector {vector3}");                              //vector(8,10)
            Console.WriteLine($"vector ({vector4.X}, {vector4.Y})");             //vector(8,10)
            Console.WriteLine(vector1 == vector2);                               //true
            Console.WriteLine(vector1 == vector3);                               //false
            Console.WriteLine(++vector1);                                        //(5,6)

            //it was Vector which was converted to int
            int v = vector1;
            Console.WriteLine(v);                                                //61


            //it was int which was converted to Vector
            int number = 10;
            Vector2D fromNumber = (Vector2D)number;

            //string interpolation use method ToString which convertss it to 2 digits - X and Y
            Console.WriteLine($"{fromNumber}");                                 //(10, 10)

            //converts to int and return whole number (integer)
            Console.WriteLine(fromNumber);                                      //200

            Console.WriteLine(fromNumber[0]);                                   //10

            //change Y to 12
            fromNumber[1] = 12;
            Console.WriteLine($"{fromNumber}");                                 //(10, 12)

            int sfsdf = fromNumber.ToInt();
            int fsdfsd = fromNumber;

            byte bt = 23;
            int wr = bt;

            byte sdf = (byte)wr;
        }

        public struct Vector2D
        {
            public int X { get; set; }

            public int Y { get; set; }

            //method allows us to pass jast class instance during call, like 'vector4' instead of {vector4.X}, {vector4.Y}
            //in other side we will get 'Lesson-15-Struct.Program_+Vector2D'
            public override string ToString() => $"({X}, {Y})";

            //this constructor can't be empty. that's why we meed to pass paramethers
            public Vector2D(int x, int y)
            {
                X = x;
                Y = y;
            }

            //indexator
            public int this[int index]
            {
                get
                {
                    if (index < 0 || index > 1) throw new ArgumentException("");
                    return index == 0 ? this.X : this.Y;
                }
                set
                {
                    if (index < 0 || index > 1) throw new ArgumentException("");
                    if (index == 0)
                    {
                        X = value;
                    }

                    this.Y = value;
                }
            }

            //Explisit - явно - от узкого к широкому
            //int a = 100;
            //object o = a;
            //Implisit  - неявно  - от широкого к узкому
            //int b = (int)o;

            //operator that converts one data type to another Implisitly
            //it was Vector which was converted to int
            public static implicit operator int(Vector2D vector2D)
            {
                //skalar vector muliplying 
                return vector2D.X * vector2D.X + vector2D.Y * vector2D.Y;
            }

            public static implicit operator float(Vector2D vector2D)
            {
                return vector2D.X * vector2D.X + vector2D.Y * vector2D.Y;
            }

            public int ToInt()
            {
                return X * X + Y * Y;
            }

            //it was int which was converted to Vector - Explisitly
            public static explicit operator Vector2D(int vector2D)
            {
                return new Vector2D(vector2D, vector2D);
            }

            public Vector2D Add(Vector2D vector2D)
            {
                //math. adding one vector to another
                //new - to not to change state of current vector. we allocate place in stack
                return new Vector2D(X + vector2D.X, Y + vector2D.Y);
            }

            //this one equals to next
            public static Vector2D Add(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
            }

            //equals to previous
            public static Vector2D operator +(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
            }

            //check if vactors are equal
            //together with == we should overload !=
            public static bool operator ==(Vector2D v1, Vector2D v2)
            {
                return v1.X == v2.X && v1.Y == v2.Y;
            }

            public static bool operator !=(Vector2D v1, Vector2D v2)
            {
                return v1.X != v2.X || v1.Y != v2.Y;
            }

            //Vector2D because we work with Vector2D data type
            public static Vector2D operator ++(Vector2D vector2D)
            {
                return new Vector2D(vector2D.X + 1, vector2D.Y + 1);
            }
        }
    }
}
