using lesson_29_EntityFramework_CW.DataAccess;
using lesson_29_EntityFramework_CW.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson_29_EntityFramework_CW
{
    public static class Program
    {
        public static async Task Main()
        {
            var context = new ShopDataContext();
            var count = context.Categories.Count();

            var categories = await context.Categories.Include(x => x.Products).ToListAsync();

            foreach(var category in categories)
            {
                Console.WriteLine($"Products in category {category.Title}");
                foreach (var product in category.Products)
                {
                    Console.WriteLine($"\t{product.Title}, price {product.Price}");
                }
            }
            Console.WriteLine(count);


            ////add category 
            //await context.Categories.AddAsync(new Category
            //{
            //    Title = "Gaming",
            //    Products = new List<Product>
            //    {
            //        new Product {Title = "PS5", Price = 233},
            //        new Product {Title = "xBox", Price = 0}
            //    }
            //});
            //await context.SaveChangesAsync();

            //print products from gaming category
            var products = await context.Products.Where(x => x.Category.Title == "Gaming").ToListAsync();
            Console.WriteLine("Gaming products");
            foreach (var product in products)
            {
                Console.WriteLine(product.Title);
            }
        }
    }
}
