using InvoicesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace InvoicesWebApp.Infrastructure.Persistance
{
    public class InvoicesWebAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompanyDetails> UserCompanyDetails { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(u => u.CreatedAt).HasDefaultValueSql("getutcdate()");
                eb.Property(u => u.Role).HasDefaultValueSql("User");
                eb.Property(u => u.IsActive).HasDefaultValue(false).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

                eb.HasOne(u => u.UserCompany)
                    .WithOne(uc => uc.User)
                    .HasForeignKey<User>(c => c.UserCompanyId);

            });

            modelBuilder.Entity<Invoice>(eb =>
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

            });
            modelBuilder.Entity<InvoiceItem>(eb =>
            {
                eb.Property(i => i.UnitPrice).HasColumnType("decimal(18,2)").HasPrecision(18, 2);
                eb.Property(i => i.VatAmount).HasColumnType("decimal(18,2)").HasPrecision(18, 2);
                eb.Property(i => i.TotalPrice).HasColumnType("decimal(18,2)").HasPrecision(18, 2);

                eb.HasOne(ii => ii.Invoice)
                    .WithMany(i => i.InvoiceItems);
            });
            modelBuilder.Entity<Product>(eb =>
            {
                eb.HasOne(p => p.User).WithMany(u => u.Products);
                eb.Property(p => p.VatRate).HasColumnType("decimal(5,2)").HasPrecision(5, 2); ;
            });
        }
    }
}
