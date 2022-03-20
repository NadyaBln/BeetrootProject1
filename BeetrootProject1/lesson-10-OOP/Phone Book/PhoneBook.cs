using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10_OOP.Phone_Book
{
    public class PhoneBook
    {
        public PhoneBookRecord[] Persons;

        public PhoneBook(PhoneBookRecord[] persons)
        {
            this.Persons = persons;
        }

        //can put it here or in class Lesson10OOP
        public void Print()
        {

            foreach (var item in this.Persons)
            {
                item.Print();
            }
        }

}
}
