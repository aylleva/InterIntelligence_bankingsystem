using AutoMapper;
using BankingSystem.Application.DTOs.Transaction;
using BankingSystem.Application.Interfaces.Repositories;
using BankingSystem.Application.Interfaces.Services;
using BankingSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BankingSystem.Persistence.Implementations.Services
{
    internal class TransactionService : ITransactionService
    {
      
        private readonly ITransactionRepository repository;
        private readonly IMapper mapper;

        public TransactionService(ITransactionRepository repository,IMapper mapper)
        {
         
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetCartsDto>> GetCarts(string userId)
        {
            var user=await repository.GetUserbyIdAsync(userId);
            if (user == null) throw new Exception("User was not found");

            var carts = repository.GetCarts(c => c.UserId == userId);
            
            return mapper.Map<IEnumerable<GetCartsDto>>(carts);
        }

        public async Task CreateCartAsync(CreateCartDto cartDto)
        {
            var user = await repository.GetUserbyIdAsync(cartDto.UserId);
            if (user is null) throw new Exception("User was not found");

            var cart = mapper.Map<Carts>(cartDto);
            
            await repository.AddAsync(cart);

            user.Carts.Add(cart);   
            await repository.SavechangesAsync();
        }

        public async  Task IncreaseBalanceAsync(ChangeBalanceDto balanceDto)
        {
           var user=await repository.GetUserbyIdAsync(balanceDto.UserId);
            if (user is null) throw new Exception("User was not found");

            var cart =await repository.GetbyIdAsync(balanceDto.CartNumber);
            if (cart is null) throw new Exception("Cart was not found");

            cart.Balance = cart.Balance + balanceDto.Amount;
            await repository.SavechangesAsync();
        }

        public async Task TransactMoneyAsync(TransactMoneyDto moneyDto)
        {
            var user = await repository.GetUserbyIdAsync(moneyDto.UserId);
            if (user is null) throw new Exception("User was not found");

            var cart= await repository.GetbyIdAsync(moneyDto.CartNumberFrom);
            var cart2 = await repository.GetbyIdAsync(moneyDto.SecondCartNumberTo);

            if (cart is null || cart2 is null) throw new Exception("Cart Datas are incorrect");

            cart.Balance=cart.Balance-moneyDto.Balance;
            cart2.Balance=cart2.Balance+moneyDto.Balance;
            await repository.SavechangesAsync();
        }
    }
}
