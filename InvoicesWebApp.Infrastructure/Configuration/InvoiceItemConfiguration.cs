using InvoicesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicesWebApp.Infrastructure.Configuration
{
    internal class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> eb)
        {
            eb.Property(i => i.UnitPrice).HasColumnType("decimal(18,2)").HasPrecision(18, 2);
            eb.Property(i => i.VatAmount).HasColumnType("decimal(18,2)").HasPrecision(18, 2);
            eb.Property(i => i.TotalPrice).HasColumnType("decimal(18,2)").HasPrecision(18, 2);

            eb.HasOne(ii => ii.Invoice)
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(i => i.InvoiceId)
            eb.HasOne(ii => ii.Product)
                .WithMany(p => p.InvoiceItems);
        }
    }
}
