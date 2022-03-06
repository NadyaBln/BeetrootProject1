using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10_OOP.Phone_Book
{
    public class PhoneBookRecord
    {
        public Person Person;
        public int Number;

        public PhoneBookRecord (Person person, int number)
        {
            this.Person = person;
            this.Number = number;
        }

        public void Print()
        {
            Console.WriteLine($"{this.Person.Name}, {this.Number}");
        }
    }
}
