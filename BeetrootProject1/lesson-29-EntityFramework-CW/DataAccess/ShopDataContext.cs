using lesson_29_EntityFramework_CW.DataAccess.Entities;
using lesson_29_EntityFramework_CW.DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;

namespace lesson_29_EntityFramework_CW.DataAccess
{
    //context = DataBase
    class ShopDataContext : DbContext
    {
        //db set = table
        //specify data type we use in each table 
        //in table Category we use object Category
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //mapping is discribing connection btw category and product
        //set mapping for product and category
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //mapping settings for category and product
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            base.OnModelCreating(modelBuilder);
        }

        //use Sql server with this connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string to DB
            optionsBuilder.UseSqlServer(@"Server=.;Database=ShopDB;Trusted_Connection=True;");
        }


    }
}
