

namespace BankingSystem.Domain.Entities
{
    public class Carts
    {
        public int Id { get; set; } 
        public string CartNumber {  get; set; }
        public string UserId {  get; set; }
        public Account User { get; set; }
        public decimal Balance {  get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;

       
    }
    
}
