using courseProject_Menu.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace courseProject_Menu.Mapping
{
    class OrdersMapping : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders", "dbo");
            builder.HasKey(x => x.OrderId);
        }
    }
}
