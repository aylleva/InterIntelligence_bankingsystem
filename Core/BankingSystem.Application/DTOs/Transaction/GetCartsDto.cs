using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.DTOs.Transaction
{
    public record GetCartsDto(string CartNumber,decimal Balance);
    
}
