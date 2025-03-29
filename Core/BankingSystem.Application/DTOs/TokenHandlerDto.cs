using BankingSystem.Domain.Entities;


namespace BankingSystem.Application.DTOs
{
    public record class TokenHandlerDto(string Token,string User,DateTime Expires);
    
}
