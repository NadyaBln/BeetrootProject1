using System;

namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        public abstract class Buyer : IPrint
        {
            public string FullName { get; set; }
            public string City { get; set; }
            public BuyerCategories BuyerCategory { get; set; }
            public abstract string PersonalInfoAboutBuyer();
            public abstract void GetOrder();

            public enum BuyerCategories
            {
                Entrepreneur,
                Individual
            }

            public void Print(IPrint print)
            {
                
            }
        }

        public class Entrepreneur : Buyer
        {
            public string CompanyName { get; set; }
            public int PolicyId { get; set; }
            public Entrepreneur(string fullName, string city, BuyerCategories BuyerCategory, string companyName, int policyId)
            {
                this.City = city;
                this.FullName = fullName;
                this.BuyerCategory = BuyerCategory;
                this.CompanyName = companyName;
                this.PolicyId = policyId;
            }
            public Entrepreneur()
            {

            }
            public override string PersonalInfoAboutBuyer()
            {
                return $"Buyer category: {BuyerCategories.Entrepreneur}, Name {FullName}, City: {City}, Id: {PolicyId}, Company Name: {CompanyName}";
            }
            public override void GetOrder()
            {

            }

            public static void Print(IPrint print)
            {
                //Question to Serhii: I want to print there paramethers (ex Companyname, City). How can I do it?
                //can't understand how pass parameters here.
                Console.WriteLine("print buyer Entrepreneur");
            }
        }

        public class Individual : Buyer
        {
            public int Age { get; set; }
            public string BirthDate { get; set; }
            public Genders Gender { get; set; }

            public Individual(string fullName, string city, BuyerCategories BuyerCategory, string bitrhDate, int age)
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
            public override string PersonalInfoAboutBuyer()
            {
                return $"Buyer category: {BuyerCategory}, Name {FullName}, City: {City}, Age: {Age}, Bitrh Date: {BirthDate}";
            }

            public enum Genders
            {
                Man,
                Woman
            }
            public string PhraseToBuyerAccorginToGender() => this.Gender == Genders.Man ? "We prepared Male clothes for you" : "We prepared Female clothes for you";

            public override void GetOrder()
            {

            }

            public static void Print(IPrint print)
            {
                //Question to Serhii: I want to print there paramethers (ex FullName, City). How can I do it?
                Console.WriteLine($"print buyer individual");
            }
        }
    }
}
