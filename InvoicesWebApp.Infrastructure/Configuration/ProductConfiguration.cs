using InvoicesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicesWebApp.Infrastructure.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> eb)
        {
            eb.Property(p => p.VatRate).HasColumnType("decimal(5,2)").HasPrecision(5, 2);

            eb.HasOne(p => p.User)
                .WithMany(u => u.Products);

            eb.HasOne(p => p.VatRate)
                .WithMany(v => v.Products)
                .HasForeignKey(p => p.VatRateId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
