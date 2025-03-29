using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.Entities
{
    public class StripeModel
    {
        public string PublishableKey {  get; set; }
        public string SecretKey {  get; set; }
    }
}
