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

            Individual Person1 = new Individual();
            Person1.BuyerCategory = "Individual";
            Person1.City = "Kyiv";
            Person1.FullName = "Ivan Ivanov";
            Person1.BirthDate = "01/01/91";
            Person1.Age = 45;

            Console.WriteLine(Person1.FullInfoAboutBuyer());

            Entrepreneur Company1 = new Entrepreneur();
            Company1.BuyerCategory = "Entrepreneur";
            Company1.City = "Lviv";
            Company1.FullName = "Dasha Plov";
            Company1.CompanyName = "Roga";
            Company1.PolicyId = 323242;

            Console.WriteLine(Company1.FullInfoAboutBuyer());
        }

        public abstract class Buyer
        {
            public string FullName;
            public string City;
            public string BuyerCategory;

            public abstract string FullInfoAboutBuyer();
            public abstract void GetOrder();
        }

        public class Entrepreneur : Buyer
        {
            public string CompanyName;
            public int PolicyId;
            public Entrepreneur(string fullName, string city, string BuyerCategory, string companyName, int policyId)
            {
                this.FullName = fullName;
                this.City = city;
                this.BuyerCategory = BuyerCategory;
                this.CompanyName = companyName;
                this.PolicyId = policyId;
            }
            public Entrepreneur()
            {

            }
            public override string FullInfoAboutBuyer()
            {
                return $"Buyer category: {BuyerCategory}, Name {FullName}, City: {City}, Id: {PolicyId}, Company Name: {CompanyName}";
            }
            public override void GetOrder()
            {

            }
        }

        public class Individual : Buyer
        {
            public int Age;
            public string BirthDate;
            public Individual (string fullName, string city, string BuyerCategory, string bitrhDate, int age)
            {
                this.FullName = fullName;
                this.City = city;
                this.BuyerCategory = BuyerCategory;
                this.Age = age;
                this.BirthDate = bitrhDate;
            }
             public Individual()
            {

            }
            public override string FullInfoAboutBuyer()
            {
                return $"Buyer category: {BuyerCategory}, Name {FullName}, City: {City}, Age: {Age}, Bitrh Date: {BirthDate}";
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
