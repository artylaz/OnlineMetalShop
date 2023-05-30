using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(c => new {c.ProductId,c.UserId});
            builder.HasIndex(c => new { c.ProductId, c.UserId }).IsUnique();
            builder.HasOne(b => b.User)
                .WithMany(u => u.Baskets).HasForeignKey(b => b.UserId);
            builder.HasOne(b => b.Product)
                .WithMany(p => p.Baskets).HasForeignKey(b => b.ProductId);
            builder.Property(b => b.AmountProduct).IsRequired();
            
        }
    }
}
