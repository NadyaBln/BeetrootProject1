using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10_OOP
{
    public class Person
    {
        public string FirstName;
        public string SurName;
        public int Age;

        //constructor (method for class instance)
        public Person (string firstName, string surName)
        {
            this.FirstName = firstName;
            this.SurName = surName;
        }

        public Person()
        {

        }

        public void Print ()
        {
            Console.WriteLine($"{this.FirstName} {SurName}, {this.Age}");
        }

        public string GetInfo()
        {
            return $"{this.FirstName} {SurName}, {this.Age}";
        }

        //static method 
        public static Person Create(string firstName, string surName)
        {
            return new Person
            {
                FirstName = firstName,
                SurName = firstName
            };
        }
    }
}
