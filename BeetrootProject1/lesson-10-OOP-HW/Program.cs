using lesson_10_OOP_HW.Library_Dir;
using System;

namespace lesson_10_OOP_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            //class Author instance
            Author firstAuthor = new();
            firstAuthor.Country = "Georgia";
            firstAuthor.BookAmount = 78;
            firstAuthor.FullName = "Boris Akunin";

            Author secondAuthor = new();
            secondAuthor.FullName = "Taras Shevchenko";
            secondAuthor.Country = "Ukraine";
            secondAuthor.BookAmount = 105;

            firstAuthor.PrintAuthor();
            Console.WriteLine(secondAuthor.GetInfo());

            //class Book instance
            Library_Dir.Book firstBook = new("Fandorin", "drama", 1997);
            Library_Dir.Book secondBook = new("Kobzar", "history", 1850);
            
            Console.WriteLine(firstBook.GetInfo());
            Console.WriteLine(secondBook.GetInfo());

            var libraryItemOne = new Library_Dir.LibraryItem(firstAuthor, firstBook);
            var libraryItrmTwo = new Library_Dir.LibraryItem(secondAuthor, secondBook);

            Library L = new (new LibraryItem[]
               {libraryItemOne,
                libraryItrmTwo
               });

            L.PrintLibrary();
        }
    }
}
