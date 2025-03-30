using BankingSystem.Domain.Entities;
using System.Linq.Expressions;


namespace BankingSystem.Application.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<Carts> GetbyIdAsync(string cartnumber);
        Task AddAsync(Carts carts);
        Task<int> SavechangesAsync();

        Task<Account> GetUserbyIdAsync(string userId);
        IQueryable<Carts> GetCarts(Expression<Func<Carts, bool>>? expression);
    }
}
