using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Persistence.Configurations
{
    internal class CartConfiguration : IEntityTypeConfiguration<Carts>
    {
        public void Configure(EntityTypeBuilder<Carts> builder)
        {
            builder.Property(c => c.CartNumber).IsRequired().HasColumnType("varchar(19)");
            builder.Property(c => c.Balance).IsRequired().HasColumnType("decimal(6,2)");
        }
    }
}
