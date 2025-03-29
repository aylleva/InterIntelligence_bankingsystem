
using BankingSystem.Application.DTOs;

namespace BankingSystem.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task CreateAccountAsync(CreateAccountDto userDto);
        Task<TokenHandlerDto> LoginAsync(LoginDto loginDto);

        Task UpdateAccountAsync(string username,UpdateAccountDto userDto);

        Task DeleteAccountAsync(string username, string password);
      
    }
}
