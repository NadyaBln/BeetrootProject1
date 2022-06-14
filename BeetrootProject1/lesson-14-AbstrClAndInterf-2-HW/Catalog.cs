using System;

namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        public class Catalog : IPrint
        {
            public Clothes[] ProductItemInCatalog;
            public Catalog(Clothes[] productItemInCatalog)
            {
                this.ProductItemInCatalog = productItemInCatalog;
            }

            public Catalog()
            {

            }

            //is it ok that I pass 'IPrint print' in method?
            public void Print(IPrint print)
            {
                //is it correct realiation? 
                //I use here method 'PrintClo()'. is it ok? or I can implement Interface without it?
                //Probably method 'PrintClo()' shoud be named just 'Print' ?
                int index = 1;
                Console.WriteLine("Please have a look at our catalog:");
                foreach (var item in this.ProductItemInCatalog)
                {
                    Console.Write($"{index}. ");
                    item.PrintClo();
                    index++;
                }
            }
        }
    }
}

