using lesson_29_EntityFramework_CW.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lesson_29_EntityFramework_CW.DataAccess.Mapping
{
    class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        //object 'Category' = table Category
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //object <Category> = table Category
            builder.ToTable("Category", "dbo");
            //primary key = Id
            builder.HasKey(x => x.Id);

        }
    }
}
