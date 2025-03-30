using AutoMapper;
using BankingSystem.Application.DTOs.Transaction;
using BankingSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.MappingProfile
{
    public class TransactionMapping:Profile
    {
        public TransactionMapping()
        {
            CreateMap<CreateCartDto, Carts>();
            CreateMap<Carts, GetCartsDto>();
        }
    }
}
