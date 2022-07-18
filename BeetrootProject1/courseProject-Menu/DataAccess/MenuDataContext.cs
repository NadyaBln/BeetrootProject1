using courseProject_Menu.Entities;
using courseProject_Menu.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject_Menu
{
    class MenuDataContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Guests> Guests { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Allergen> Allergens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping settings for category and product
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new OrdersMapping());
            modelBuilder.ApplyConfiguration(new GuestsMapping());
            modelBuilder.ApplyConfiguration(new CategoriesMapping());
            modelBuilder.ApplyConfiguration(new AllergenMapping());
            base.OnModelCreating(modelBuilder);
        }

        //use Sql server with this connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string to DB
            optionsBuilder.UseSqlServer(@"Server=.;Database=RestaurantMenu;Trusted_Connection=True;");
        }

    }
}
