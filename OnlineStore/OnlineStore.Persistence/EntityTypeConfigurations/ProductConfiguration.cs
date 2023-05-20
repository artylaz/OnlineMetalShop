using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.HasIndex(pr => pr.Id).IsUnique();
            builder.Property(pr => pr.Name).HasMaxLength(80).IsRequired();
            builder.Property(pr => pr.Description).HasMaxLength(2000).IsRequired();
            builder.Property(pr => pr.IsHidden).IsRequired();
            builder.Property(pr => pr.CreationDate).IsRequired();
            builder.HasOne(pr => pr.Category)
                .WithMany(c => c.Products).HasForeignKey(pr => pr.CategoryId);
        }
    }
}
