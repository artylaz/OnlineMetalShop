using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(or=> new { or.OrderId, or.ProductId});
            builder.HasIndex(or => new { or.OrderId, or.ProductId }).IsUnique();
            builder.Property(or => or.ProductCount).IsRequired();
            builder.Property(or => or.ProductPrice).IsRequired();
            builder.HasOne(or => or.Order).WithMany(pr => pr.OrderItems).HasForeignKey(d => d.OrderId);
            builder.HasOne(or => or.Product).WithMany(st => st.OrderItems).HasForeignKey(d => d.ProductId);
        }
    }
}
