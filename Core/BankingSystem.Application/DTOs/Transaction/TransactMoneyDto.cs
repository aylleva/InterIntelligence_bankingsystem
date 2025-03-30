

namespace BankingSystem.Application.DTOs.Transaction
{
     public record class TransactMoneyDto(string UserId,string CartNumberFrom,string SecondCartNumberTo,decimal Balance);
  
}
