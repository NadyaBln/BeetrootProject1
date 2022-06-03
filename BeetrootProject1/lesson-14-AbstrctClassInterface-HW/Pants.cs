namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        public class Pants : Clothes
        {
            public int Length;

            public Pants(string itemName, string gender, string color, int itemId, int size, string category, int price)
            {
                this.ItemName = itemName;
                this.Gender = gender;
                this.Color = color;
                this.ItemId = itemId;
                this.Length = size;
                this.Category = category;
                this.Price = price;
            }
            public Pants()
            {

            }
            public override string GetFullProductInfo()
            {
                return $"Full Product Info about # {ItemId}: Name: {ItemName}, Length: {Length}, Sex: {Gender}, Color: {Color}";
            }

            public override void Badge(IOrderANameBadge iOrderANameBadge)
            {
                iOrderANameBadge.Badge(string.Empty);
            }
        }
    }
}
