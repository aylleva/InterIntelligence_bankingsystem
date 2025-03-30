
using Microsoft.AspNetCore.Identity;

namespace BankingSystem.Domain.Entities
{
    public class Account:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public string? Image { get; set; }
        public ICollection<Carts> Carts { get; set; }
        
    }
}
