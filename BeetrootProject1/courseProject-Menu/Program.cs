using courseProject_Menu.DataAccess;
using System.Threading.Tasks;

namespace courseProject_Menu
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var context = new MenuDataContext();
            //var count = context.Categories.Count();


            ////add order
            //await context.Orders.AddAsync(new Orders
            //{
            //    OrderId = 1,
            //    ProductId = 1,
            //    Amount = 1,
            //    CreationDateTime = DateTime.Now,
            //    GuestId = 1,
            //    TableNumber = 5
            //});
            //await context.SaveChangesAsync();

            ////add product
            //await context.Products.AddAsync(new Product
            //{
            //    Title = "Chicken Soup",
            //    Price = 12,
            //    Description = "A soup made from chicken, simmered in water, usually with various other ingredients.",
            //    CategoryId = 1,
            //    IsAlcohol = false,
            //    IsSeason = false,
            //    AllergenId = 1,
            //    IsActive = true
            //}) ;
            //await context.SaveChangesAsync();

            ////add category
            //await context.Categories.AddAsync(new Categories
            //{
            //    CategoryName = "Additional",
            //    Description = "Bread, honey, butter, other",
            //});
            //await context.SaveChangesAsync();

            await AdminActions.AddAllergenAsync("Soya");
            await UserActions.CreateOrderAsync(2, 5, 1);
        }
    }
}
