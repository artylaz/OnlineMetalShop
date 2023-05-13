using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Persistence.EntityTypeConfigurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(pi => pi.Id);
            builder.HasIndex(pi => pi.Id).IsUnique();
            builder.Property(pi => pi.Name).HasMaxLength(50).IsRequired();
            builder.Property(pi => pi.Path).HasMaxLength(255).IsRequired();
            builder.HasOne(pi=>pi.Product).WithMany(pr=>pr.Pictures).HasForeignKey(pi => pi.ProductId);
        }
    }
}
