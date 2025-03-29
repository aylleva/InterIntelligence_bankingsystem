
using BankingSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankingSystem.Persistence.DAL
{
    public class AppDbContext:IdentityDbContext<Account>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
