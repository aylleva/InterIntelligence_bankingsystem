using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Persistence.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasColumnType("varchar(20)");
            builder.Property(a => a.Surname).IsRequired().HasColumnType("varchar(40)");
            builder.Property(a => a.CartNumber).IsRequired().HasColumnType("varchar(19)");
        }
    }
}
