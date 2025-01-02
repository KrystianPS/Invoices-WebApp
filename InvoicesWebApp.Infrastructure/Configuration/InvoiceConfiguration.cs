using InvoicesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicesWebApp.Infrastructure.Configuration
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> eb)
        {
            eb.Property(i => i.Status).HasDefaultValue("draft");
            eb.Property(i => i.IsEmailSent).HasDefaultValue(false).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            eb.HasOne(i => i.User)
                .WithMany(u => u.Invoices)
                .OnDelete(DeleteBehavior.NoAction);
            eb.HasOne(i => i.Contractor)
                        .WithMany(c => c.Invoices)
                        .HasForeignKey(i => i.ContractorId)
                        .OnDelete(DeleteBehavior.Cascade);
            eb.HasOne(i => i.UserCompany)
                        .WithMany(uc => uc.CompanyInvoices)
                        .HasForeignKey(i => i.UserCompanyId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
