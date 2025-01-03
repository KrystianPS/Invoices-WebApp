using InvoicesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;



namespace InvoicesWebApp.Infrastructure.Persistance
{
    public class InvoicesWebAppDbContext : DbContext
    {

        public InvoicesWebAppDbContext(DbContextOptions<InvoicesWebAppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompanyDetails> UserCompanyDetails { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
