using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10_OOP_HW.Library_Dir
{
    public class Book
    {
        public string BookName;
        public Author BookAuthor;
        public string BookGenre;
        public int BookYear;

        public Book (string bookName, Author bookAuthor, string bookGenre, int bookYear)
        {
            BookName = bookName;
            BookGenre = bookGenre;
            BookAuthor = bookAuthor;
            BookYear = bookYear;
        }

        public string GetInfo()
        {
            return $"Info about Book: Book Name: {BookName}, Author {BookAuthor.FullName}, Genre: {BookGenre}, Year: {BookYear}";
        }
    }
}
