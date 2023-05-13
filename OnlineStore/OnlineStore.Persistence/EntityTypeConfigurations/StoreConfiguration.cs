using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.HasIndex(pr => pr.Id).IsUnique();
            builder.Property(pr => pr.StoreName).HasMaxLength(80).IsRequired();
            builder.Property(pr => pr.Address).HasMaxLength(200).IsRequired();
            builder.Property(pr => pr.IsHidden).IsRequired();
        }
    }
}
