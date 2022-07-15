using courseProject_Menu.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject_Menu
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var context = new MenuDataContext();
            var count = context.Categories.Count();

            //var orders = await context.Orders.Include(x => x.Product).ToListAsync();

            //foreach (var order in orders)
            //{
            //    Console.WriteLine($"Products in order {order.Product}");
            //    foreach (var product in order.Product)
            //    {
            //        Console.WriteLine($"\t{product.Title}, price {product.Price}");
            //    }
            //}
            //Console.WriteLine(count);

            //add order 
            //await context.Orders.AddAsync(new Orders
            //{
            //    OrderId = 1,
            //    ProductId = 2,
            //    //ProductId = new List<Product>
            //    //{
            //    //    new Product {ProductId = 1, Title = "Bread", Price = 3, Amount = 1, CategoryId = 2, IsAlcohol = false, IsSeason = false, AllergenId = 1},
            //    //},
            //    CreationDateTime = DateTime.Now,
            //    GuestId = 1,
            //    TableNumber = 5
            //});
            //await context.SaveChangesAsync();

            await context.Products.AddAsync(new Product
            {
            ProductId = 1, 
                Title = "Bread", 
                Price = 3, 
                Amount = 1, 
                CategoryId = 2, 
                IsAlcohol = false, 
                IsSeason = false, 
                AllergenId = 1
         
           
            });
            await context.SaveChangesAsync();
        }
    }
}
