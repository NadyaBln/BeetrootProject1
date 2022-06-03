using System;

namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        static void Main(string[] args)
        {
            //Describe with UML ‘internet shop’ domain.
            //It should include products (with price, quantity, etc.),
            //buyers (personal information), receipts (what was sold and to whom), etc.
            //Implement all entities in C# program
            //Provide console interface to register new product, add quantity to existent, sell product, register buyer.

            Pants Pants_1 = new Pants();
            Pants_1.ItemId = 1;
            Pants_1.Color = "Yellow";
            Pants_1.Gender = "M";
            Pants_1.ItemName = "Pants Yellow Cup";
            Pants_1.Length = 1;
            Pants_1.Price = 15;

            Console.WriteLine(Pants_1.GetFullProductInfo());
            Pants_1.Badge(new PantsBadge());

            TShorts Tshort_1 = new TShorts();
            Tshort_1.ItemId = 2;
            Tshort_1.ItemName = "T-Short Fewer";
            Tshort_1.Size = "M";
            Tshort_1.IsPrint = true;
            Tshort_1.Gender = "W";
            Tshort_1.Color = "Red";
            Tshort_1.Price = 9;

            Console.WriteLine(Tshort_1.GetFullProductInfo());
            Tshort_1.Badge(new TshortBadge());
        }

        public abstract class Buyer
        {
            public string FullName;
            public string City;
            public string BuyerCategory;

            public abstract void FullInfoAboutByer();
            public abstract void GetOrder();
        }

        public class Entrepreneur : Buyer
        {
            public override void FullInfoAboutByer()
            {
                
            }
            public override void GetOrder()
            {

            }
        }

        public class Individual : Buyer
        {
            public override void FullInfoAboutByer()
            {

            }
            public override void GetOrder()
            {

            }
        }

        //заказать именную нашивку
        public interface IOrderANameBadge
        {
            public void Badge(string itemName);
        }

        public class TshortBadge : IOrderANameBadge
        {
            public void Badge(string itemName)
            {
                Console.WriteLine($"Yes, I would like to order a Name Badge for my T-short");
            }
        }

        public class PantsBadge : IOrderANameBadge
        {
            public void Badge(string itemName)
            {
                Console.WriteLine($"Yes, I would like to order a Name Badge for my pants");
            }
        }
    }
}
