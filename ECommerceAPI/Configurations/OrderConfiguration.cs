using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id); // Primary Key

            builder.Property(o => o.Quantity)
                .IsRequired(); // Quantity alanı zorunlu

            builder.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId); // Foreign Key
        }
    }
}
