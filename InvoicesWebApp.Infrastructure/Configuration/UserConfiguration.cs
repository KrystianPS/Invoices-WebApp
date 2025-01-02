using InvoicesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicesWebApp.Infrastructure.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> eb)
        {
            eb.Property(u => u.CreatedAt).HasDefaultValueSql("getutcdate()");
            eb.Property(u => u.Role).HasDefaultValueSql("User");
            eb.Property(u => u.IsActive).HasDefaultValue(false).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            eb.HasOne(u => u.UserCompany)
                .WithOne(uc => uc.User)
                .HasForeignKey<User>(c => c.UserCompanyId);
        }
    }
}
