using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(d =>new { d.ProductId, d.StoreId });
            builder.HasIndex(d => new { d.ProductId, d.StoreId }).IsUnique();
            builder.Property(d => d.DeliveryDate).IsRequired();
            builder.Property(d => d.ProductCount).IsRequired();
            builder.HasOne(d => d.Product).WithMany(pr => pr.Deliveries).HasForeignKey(d => d.ProductId);
            builder.HasOne(d => d.Store).WithMany(st => st.Deliveries).HasForeignKey(d => d.StoreId);
        }
    }
}
