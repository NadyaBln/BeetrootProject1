using courseProject_Menu.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace courseProject_Menu.DataAccess
{
    class UserActions
    {
        public static async Task CreateOrderAsync(int OrderId, int ProductId, int TableNumber, string GuestName, string GuestEmail)
        {
            var context = new MenuDataContext();
            await context.Guests.AddAsync(new Guests
            {
                GuestName = GuestName,
                OrderId = OrderId,
                GuestEmail = GuestEmail
            });

            //try to get GuestId 
            //var GuestId = await context.Guests.Select(x => x.GuestId).ToListAsync().Last();

            await context.Orders.AddAsync(new Orders
            {
                OrderId = OrderId,
                ProductId = ProductId,
                CreationDateTime = DateTime.Now,
                GuestId = GuestId,
                TableNumber = TableNumber
            });
            await context.SaveChangesAsync();
        }
    }
}
