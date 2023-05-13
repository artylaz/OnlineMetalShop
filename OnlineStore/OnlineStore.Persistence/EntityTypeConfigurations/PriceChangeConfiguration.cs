using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class PriceChangeConfiguration : IEntityTypeConfiguration<PriceChange>
    {
        public void Configure(EntityTypeBuilder<PriceChange> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.HasIndex(pr => pr.Id).IsUnique();
            builder.Property(pr => pr.DatePriceChange).IsRequired();
            builder.Property(pr => pr.NewPrice).IsRequired();
            builder.HasOne(pr => pr.Product).WithMany(pr => pr.PriceChanges).HasForeignKey(pr => pr.ProductId);
        }
    }
}
