using BankingSystem.Application.DTOs;
using BankingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.Interfaces.Services
{
    public interface ITokenHandler
    {
        TokenHandlerDto CreateToken(Account user, int minutes);
    }
}
