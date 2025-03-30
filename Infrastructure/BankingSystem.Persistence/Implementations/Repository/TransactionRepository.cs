using BankingSystem.Application.Interfaces.Repositories;
using BankingSystem.Domain.Entities;
using BankingSystem.Persistence.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Persistence.Implementations.Repository
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Account> usermeneger;

        public TransactionRepository(AppDbContext context,UserManager<Account> usermeneger)
        {
            _context = context;
            this.usermeneger = usermeneger;
        }
        public async Task AddAsync(Carts carts)
        {
            await _context.Carts.AddAsync(carts);
        }

        public async Task<Carts> GetbyIdAsync(string cartnumber)
        {
           return await _context.Carts.FirstOrDefaultAsync(x=>x.CartNumber==cartnumber);
        }

        public IQueryable<Carts> GetCarts(Expression<Func<Carts, bool>>? expression)
        {
            return _context.Carts.Where(expression);
        }

        public async Task<Account> GetUserbyIdAsync(string userId)
        {
            return await usermeneger.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<int> SavechangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
