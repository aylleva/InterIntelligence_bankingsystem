using BankingSystem.Application.DTOs.Transaction;


namespace BankingSystem.Application.Interfaces.Services
{
    public interface ITransactionService
    {
        Task CreateCartAsync(CreateCartDto cartDto);
        Task IncreaseBalanceAsync(ChangeBalanceDto balanceDto);
        Task TransactMoneyAsync(TransactMoneyDto moneyDto);
        public Task<IEnumerable<GetCartsDto>> GetCarts(string userId);
    }
}
