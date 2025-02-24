using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            // Soft Delete için filtreleme
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
