using courseProject_Menu.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courseProject_Menu.Mapping
{
    class CategoriesMapping : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories", "dbo");
            builder.HasKey(x => x.CategoryId);
        }
    }
}
