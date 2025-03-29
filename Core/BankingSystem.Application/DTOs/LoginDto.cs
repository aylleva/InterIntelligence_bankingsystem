using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTOs
{
    public record class LoginDto(string UsernameOrEmail,string Password);    
   
}
