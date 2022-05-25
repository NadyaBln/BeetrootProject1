using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10_OOP_HW.Library_Dir
{
     class LibraryItem
    {
        public Author Author;
        public Book Book;

        public LibraryItem(Author author, Book book)
        {
            this.Author = author;
            this.Book = book;
        }

        public string GetLibraryItem()
        {
            return $"{this.Author.FullName}, {this.Book.BookName}";
        }

        public void PrintLibrary()
        {
            Console.WriteLine($"{this.Author.FullName}, {this.Book.BookName}");
        }
    }
}
