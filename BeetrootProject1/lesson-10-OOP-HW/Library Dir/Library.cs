using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10_OOP_HW.Library_Dir
{
     class Library
    {
        public LibraryItem[] ItemBook;

        public Library (LibraryItem[] itembook)
        {
            this.ItemBook = itembook;
        }

        public void PrintLibrary()
        {
            foreach (var item in this.ItemBook)
            {
                Console.WriteLine(item.GetLibraryItem());
            }
        }
    }
}
