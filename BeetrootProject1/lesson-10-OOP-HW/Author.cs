using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10_OOP_HW
{
   public class Author
    {
        public string FullName;
        public string Country;
        public int BookAmount;

        public Author(string fullName, string country, int bookAmount)
        {
            this.FullName = fullName;
            this.Country = country;
            this.BookAmount = bookAmount;
        }

        public Author()
        {

        }

        public void PrintAuthor()
        {
            Console.WriteLine($"Info about Author: {FullName}, Country: {Country} , books: {BookAmount}");
        }

        public string GetInfo()
        {
            return $"Info about author: {FullName}, Country {Country}, books: {BookAmount}";
        }
    }
}
