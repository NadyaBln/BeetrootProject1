using System;

namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        public abstract class Clothes
        {
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public CloGender ClGender { get; set; }
            public string Color { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
            public ClothesCategories clothesCategories { get; set; }
            public abstract string GetFullProductInfo();
            public abstract bool IsClothesAvailable();
            public abstract void PrintClo();
            public enum ClothesCategories
            {
                Pants,
                Tshort
            }
            public enum CloGender
            {
                M,
                W
            }
        }

        public class Pants : Clothes
        {
            public int Length { get; set; }

            public Pants(string itemName, CloGender clGender, string color, int itemId, ClothesCategories clothesCategories, int price, int quantity, int length)
            {
                this.ItemName = itemName;
                this.ClGender = clGender;
                this.Color = color;
                this.ItemId = itemId;
                this.Length = length;
                this.clothesCategories = clothesCategories;
                this.Price = price;
                this.Quantity = quantity;
            }
            public Pants()
            {

            }
            public override string GetFullProductInfo()
            {
                return $"Full Product Info about # {ItemId}: Name: {ItemName}, Length: {Length}, Sex: {ClGender}, Color: {Color}";
            }
            public override bool IsClothesAvailable() => Quantity > 0 ? true : false;

            public override void PrintClo()
            {
                Console.WriteLine($"Title: {ItemName}, Quantity: {Quantity}, Price: {Price}");
            }
        }

        public class TShorts : Clothes
        {
            public bool IsPrint { get; set; }
            public string Size { get; set; }

            public TShorts(string itemName, CloGender clGender, string color, int itemId, ClothesCategories clothesCategories, int price, int quantity, bool isPrint, string size)
            {
                this.ItemName = itemName;
                this.ClGender = clGender;
                this.Color = color;
                this.ItemId = itemId;
                this.Price = price;
                this.Quantity = quantity;
                this.Size = size;
                this.IsPrint = isPrint;
                this.clothesCategories = clothesCategories;
                this.Price = price;
            }
            public TShorts()
            {

            }

            public override string GetFullProductInfo()
            {
                return $"Full Product Info about # {ItemId}: Name: {ItemName}, Sex: {ClGender}, Color: {Color}, Size: {Size}, With Print: {IsPrint}";
            }
            public override bool IsClothesAvailable() => Quantity > 0 ? true : false;

            public override void PrintClo()
            {
                Console.WriteLine($"Title: {ItemName}, Quantity: {Quantity}, Price: {Price}");
            }
        }
    }
}

