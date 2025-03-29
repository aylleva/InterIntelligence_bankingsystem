using AutoMapper;
using BankingSystem.Application.DTOs;
using BankingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.MappingProfile
{
    internal class AccountMapping:Profile
    {
        public AccountMapping()
        {
            CreateMap<CreateAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();
        }
    }
}
