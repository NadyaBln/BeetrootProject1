using courseProject_Menu.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courseProject_Menu.Mapping
{
    class AllergenMapping : IEntityTypeConfiguration<Allergen>
    {
        public void Configure(EntityTypeBuilder<Allergen> builder)
        {
            builder.ToTable("Allergens", "dbo");
            builder.HasKey(x => x.AllergenId);
        }
    }
}
