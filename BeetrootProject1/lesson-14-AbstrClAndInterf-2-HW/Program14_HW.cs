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

            Pants Pants_1 = new();
            Pants_1.ItemId = 1;
            Pants_1.Color = "Yellow";
            Pants_1.ClGender = Clothes.CloGender.M;
            Pants_1.ItemName = "Pants Yellow Cup";
            Pants_1.Length = 1;
            Pants_1.Price = 15;
            Pants_1.Quantity = 123;

            Console.WriteLine(Pants_1.GetFullProductInfo());
            Console.WriteLine();


            Pants Pants_2 = new Pants("Pants Lovely Meeting", Clothes.CloGender.W, "Blue", 3, Clothes.ClothesCategories.Pants, 23, 10, 40);
            Console.WriteLine(Pants_2.GetFullProductInfo());
            Console.WriteLine();


            Pants Pants_3 = new Pants("Pants Go Home", Clothes.CloGender.W, "Blue", 3, Clothes.ClothesCategories.Pants, 12, 7, 35);
            Console.WriteLine();


            TShorts Tshort_1 = new TShorts();
            Tshort_1.ItemId = 2;
            Tshort_1.ItemName = "T-Short Fewer";
            Tshort_1.Size = "M";
            Tshort_1.IsPrint = true;
            Tshort_1.ClGender = Clothes.CloGender.M;
            Tshort_1.Color = "Red";
            Tshort_1.Price = 9;
            Tshort_1.Quantity = 322;

            Console.WriteLine(Tshort_1.GetFullProductInfo());
            Console.WriteLine();

            TShorts Tshort_2 = new TShorts("Tshort Nirvana", Clothes.CloGender.W, "White", 4, Clothes.ClothesCategories.Tshort, 100, 3, true, "L");
            TShorts Tshort_3 = new TShorts("My first date", Clothes.CloGender.M, "Orange", 4, Clothes.ClothesCategories.Tshort, 100, 0, false, "L");
            Console.WriteLine($"Is item '{Tshort_3.ItemName}' in stock: {Tshort_3.IsClothesAvailable()}");
            Console.WriteLine();

            Individual Person1 = new Individual();
            Person1.BuyerCategory = Buyer.BuyerCategories.Individual;
            Person1.City = "Kyiv";
            Person1.FullName = "Ivan Ivanov";
            Person1.BirthDate = "01/01/91";
            Person1.Age = 45;
            Person1.Gender = Individual.Genders.Man;

            Console.WriteLine($"{Person1.FullName}'s profile: {Person1.PersonalInfoAboutBuyer()}");
            Console.WriteLine($"{Person1.PhraseToBuyerAccorginToGender()}, {Person1.FullName}");
            Console.WriteLine();


            Individual Person2 = new Individual();
            Person2.BuyerCategory = Buyer.BuyerCategories.Individual;
            Person2.City = "Brovary";
            Person2.FullName = "Ivanna Petrova";
            Person2.BirthDate = "01/01/96";
            Person2.Age = 15;
            Person2.Gender = Individual.Genders.Woman;

            Console.WriteLine(Person2.PersonalInfoAboutBuyer());
            Console.WriteLine(Person2.PhraseToBuyerAccorginToGender());
            Console.WriteLine($"{Person2.FullName}'s gender is {Person2.Gender}");
            Console.WriteLine($"{Person2.FullName}'s category is {Person2.BuyerCategory}");
            Console.WriteLine();


            Entrepreneur Company1 = new Entrepreneur();
            Company1.BuyerCategory = Buyer.BuyerCategories.Entrepreneur;
            Company1.City = "Lviv";
            Company1.FullName = "Dasha Plov";
            Company1.CompanyName = "Roga";
            Company1.PolicyId = 323242;

            Console.WriteLine(Company1.PersonalInfoAboutBuyer());
            Console.WriteLine($"Buyer category is {Company1.BuyerCategory}");
            Console.WriteLine();

            Catalog Catalog1 = new Catalog(new Clothes[]
            {
                Tshort_1,
                Tshort_2,
                Tshort_3,
                Pants_1,
                Pants_2,
                Pants_3
            });

            Catalog1.Print(new Catalog());
            Console.WriteLine();

            Entrepreneur.Print(new Entrepreneur());
            Individual.Print(new Individual());
            Console.WriteLine();

            Clothes[] buyersOrder1 = new Clothes[] { Tshort_1, Pants_2 };
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);

            //Question to Serhii:
            //why it doesn't work (System.NullReferenceException) when I use default/empty constructor of Order? 
            //like that -> Order Order1 = new Order();
            Order Order1 = new Order(date1, 101, buyersOrder1, Person1, Order.OrderStatus.InProcess);
            Order1.Print(new Order(date1, 1, buyersOrder1, Person1, Order.OrderStatus.InProcess));
            Order1.Delivery(Order1, true);
        }

        public interface IPrint
        {
            void Print(IPrint message);
        }

        //Question to Serhii:
        //I tried to create separate class for Print. But decided to inherit interface IPrint in class Buyer.
        //is it correct decision?

        //public class PrintBuyer : IPrint
        //{
        //    public void Print(string message)
        //    {
        //        Console.WriteLine($"{}");
        //    }
        //}
        public interface IDelivery
        {
            public void Delivery(Order order, bool answer);
        }
    }
}
