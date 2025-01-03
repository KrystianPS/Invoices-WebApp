using InvoicesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicesWebApp.Infrastructure.Configuration
{
    internal class VatRateConfiguration : IEntityTypeConfiguration<VatRate>
    {
        public void Configure(EntityTypeBuilder<VatRate> eb)
        {
            eb.Property(v => v.VatRateThreshold).HasColumnType("decimal(18,4)");

            eb.HasData(
        new VatRate { Id = 1, VatRateThreshold = 23.00M, VatRateNameReference = "Stawka podstawowa (23%)" },
        new VatRate { Id = 2, VatRateThreshold = 8.00M, VatRateNameReference = "Stawka obniżona (8%)" },
        new VatRate { Id = 3, VatRateThreshold = 5.00M, VatRateNameReference = "Stawka obniżona (5%)" },
        new VatRate { Id = 4, VatRateThreshold = 0.00M, VatRateNameReference = "Stawka 0%" });

            eb.HasIndex(v => v.VatRateThreshold)
                .IsUnique();
        }


    }
}
