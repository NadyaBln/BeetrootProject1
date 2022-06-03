namespace lesson_14_AbstrctClassInterface_HW
{
    partial class Program14_HW
    {
        public class TShorts : Clothes
        {
            public bool IsPrint;
            public string Size;

            public TShorts(string size, bool isPrint, string category, int price)
            {
                this.Size = size;
                this.IsPrint = isPrint;
                this.Category = category;
                this.Price = price;
            }
            public TShorts()
            {

            }

            public override string GetFullProductInfo()
            {
                return $"Full Product Info about # {ItemId}: Name: {ItemName}, Sex: {Gender}, Color: {Color}, Size: {Size}, With Print: {IsPrint}";
            }
            public override void Badge(IOrderANameBadge iOrderANameBadge)
            {
                iOrderANameBadge.Badge(string.Empty);
            }
        }
    }
}
