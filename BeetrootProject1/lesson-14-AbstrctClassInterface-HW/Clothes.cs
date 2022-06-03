namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        public abstract class Clothes
        {
            public int ItemId;
            public string ItemName;
            public string Gender;
            public string Color;
            public string Category;
            public int Price;

            public abstract string GetFullProductInfo();

            public abstract void Badge(IOrderANameBadge iOrderANameBadge);
        }
    }
}
