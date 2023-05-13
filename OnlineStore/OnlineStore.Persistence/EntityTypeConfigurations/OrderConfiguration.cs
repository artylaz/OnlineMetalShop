using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(or => or.Id);
            builder.HasIndex(or => or.Id).IsUnique();
            builder.Property(or => or.UserId).IsRequired();
            builder.Property(or => or.CreationDate).IsRequired();
            builder.HasOne(or => or.OrderStatus).WithMany(pr => pr.Orders).HasForeignKey(d => d.OrderStatusId);
            builder.HasOne(or => or.Store).WithMany(st => st.Orders).HasForeignKey(d => d.StoreId);
        }
    }
}
