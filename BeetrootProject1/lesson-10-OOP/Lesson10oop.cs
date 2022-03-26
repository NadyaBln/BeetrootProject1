using lesson_10_OOP.Phone_Book;
using System;

namespace lesson_10_OOP
{
    class Lesson10oop
    {
        static void Main(string[] args)
        {

            //create class instance
            Person person = new Person();
            person.FirstName = "Serhii";
            person.SurName = "Olefir";
            person.Age = 10;
    

            //Console.WriteLine($"{person.FirstName} {person.SurName}, {person.Age}");

            //constructor
            Person otherPerson = new Person("Alex", "Smith");
            //Console.WriteLine($"{otherPerson.FirstName} {otherPerson.SurName}, {otherPerson.Age}");
            otherPerson.Age = 102;

            otherPerson.Print();
            person.Print();

            Console.WriteLine(otherPerson.GetInfo());

            var secondPerson = Person.Create("Nick", "Swwe");
            secondPerson.Print();

            var record = new Phone_Book.PhoneBookRecord(new Phone_Book.Person("Oleh"), 323443232);
            var otherRecord = new Phone_Book.PhoneBookRecord(new Phone_Book.Person("Oleh 2"), 123443232);

            PhoneBook book = new PhoneBook(new PhoneBookRecord[]
            {
                record,
                otherRecord
            });

            record.Person.SetName("Alexx");
            book.Print();
            //record.Print();
        }
    }
}
