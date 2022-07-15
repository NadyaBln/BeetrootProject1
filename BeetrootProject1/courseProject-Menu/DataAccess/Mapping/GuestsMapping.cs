using courseProject_Menu.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courseProject_Menu.Mapping
{
    class GuestsMapping : IEntityTypeConfiguration<Guests>
    {
        public void Configure(EntityTypeBuilder<Guests> builder)
        {
            builder.ToTable("Guests", "dbo");
            builder.HasKey(x => x.GuestId);
        }
    }
}
