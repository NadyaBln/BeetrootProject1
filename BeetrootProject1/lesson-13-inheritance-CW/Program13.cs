using System;

namespace lesson_13_inheritance_CW
{
    class Program13
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal
            {
                Name = "Sima",
                PawsCount = 4
            };
            Cat firstCat = new Cat
            {
                Name = "Capuchinka",
                PawsCount = 4
            };
            Cat secondCat = new Cat
            {
                Name = "Varis",
                PawsCount = 4
            };
            Dog dog = new Dog
            {
                Name = "Lacki",
                PawsCount = 4
            };

            Console.WriteLine($"Animal {animal.Name} with {animal.PawsCount} paws");
            Console.WriteLine($"Cat {firstCat.Name} with {firstCat.PawsCount} paws");

            animal.MakeNoize();
            firstCat.MakeNoize();
            dog.MakeNoize();

            Animal a;
            a = new Cat
            {
                Name = "Busia"
            };

            //there is ex of polimorfism. because 'a' said Meow
            a.MakeNoize();
            Console.WriteLine(a.GetType());

            a = new Dog
            {
                Name = "Sami"
            };

            //and 'b' here said Bowwow
            a.MakeNoize();
            Console.WriteLine(a.GetType());
            Console.WriteLine(a is Cat); //false
            Console.WriteLine(a is Dog); //true 

            Console.WriteLine(firstCat.Equals(firstCat)); //true
            Console.WriteLine($"{firstCat.Name} equal {secondCat.Name} = {firstCat.Equals(secondCat)}"); //true

            object obj1 = 4;
            object obj2 = "Somee string";

            Console.WriteLine(obj1.ToString());
            Console.WriteLine(obj2.ToString());
            Console.WriteLine(obj1.GetType());
            Console.WriteLine(obj2.GetType());

            obj1 = false;
            Console.WriteLine(obj1.ToString());
            Console.WriteLine(obj1.GetType());

            //incorrect because this is not a digit
            //Console.WriteLine((int)obj1);
            Console.WriteLine(obj1 as int?);

            //ex of polymorphizm 
            Noise noise;
            noise = new FlyNoise();
            noise.MakeNoise();

            noise = new JustNoise();
            noise.MakeNoise();

            var duck = new Duck(new FlyNoise());
            var duck1 = new Duck(new JustNoise());
            duck.MakeNoise();
            duck1.MakeNoise();
        }
    }

    public class Cat : Animal
    {
        public override void MakeNoize()
        {
            Console.WriteLine($"{ base.Name} said Meow!");
        }
    }

    public class Dog : Animal
    {
        public override void MakeNoize()
        {
            Console.WriteLine($"{ base.Name} said BowWow!");
        }
    }

    //move 'noise' to separate class to make Duks appropriate to open-close SOLID principle 
    public abstract class Noise
    {
        public abstract void MakeNoise();
    }

    public class FlyNoise : Noise
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Літаючий кря!");
        }
    }

    public class SilentNoise : Noise
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Тихий кря!");
        }
    }

    public class JustNoise : Noise
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Просто кря!");
        }
    }

    public class Duck
    {
        private readonly Noise _noise;

        public Duck(Noise noise)
        {
            this._noise = noise;
        }

        public virtual void MakeNoise()
        {
            this._noise.MakeNoise();
        }
    }

    public class RubberDuck : Duck
    {
        public RubberDuck(Noise noise) : base(noise)
        {
        }
    }

    public class RealDuck : Duck
    {
        public RealDuck(Noise noise) : base(noise)
        {
        }
    }

    public class FlyDuck : RealDuck
    {
        public FlyDuck(Noise noise) : base(noise)
        {
        }
    }
}
