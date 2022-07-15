using lesson_29_EntityFramework_CW.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lesson_29_EntityFramework_CW.DataAccess.Mapping
{
    class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //object <Products> = table Products
            builder.ToTable("Products", "dbo");
            //primary key = Id
            builder.HasKey(x => x.Id);
            //many to many
            //relation btw category and product
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    
    }
}
