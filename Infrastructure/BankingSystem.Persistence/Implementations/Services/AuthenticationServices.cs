using AutoMapper;
using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Services;
using BankingSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace BankingSystem.Persistence.Implementations.Services
{
    internal class AuthenticationServices : IAuthenticationService
    {
        private readonly UserManager<Account> usermeneger;
        private readonly IMapper mapper;
        private readonly ITokenHandler tokenhandler;

        public AuthenticationServices(UserManager<Account> usermeneger,IMapper mapper,ITokenHandler tokenhandler)
        {
            this.usermeneger = usermeneger;
            this.mapper = mapper;
            this.tokenhandler = tokenhandler;
        }
        public async Task CreateAccountAsync(CreateAccountDto userDto)
        {
            if (await usermeneger.Users.AnyAsync(u => u.UserName == userDto.Username)) throw new Exception("Username is already exist");

            var user =mapper.Map<Account>(userDto);

            var result = await usermeneger.CreateAsync(user, userDto.Password);

            StringBuilder message= new StringBuilder(); 
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    message.AppendLine(error.Description);
                }
                throw new Exception(message.ToString());
            }

        }
        public async Task<TokenHandlerDto> LoginAsync(LoginDto loginDto)
        {
          var user=await usermeneger.Users.FirstOrDefaultAsync(u=>u.UserName==loginDto.UsernameOrEmail|| u.Email==loginDto.UsernameOrEmail);
            if (user == null) throw new Exception("Username/Email or Password is inccorrect");

          var result=await usermeneger.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new Exception("Username/Email or Password is inccorrect");

            return tokenhandler.CreateToken(user, 30);
        }

        public async Task UpdateAccountAsync(string username,UpdateAccountDto userDto)
        {
            var user=await usermeneger.Users.FirstOrDefaultAsync(u=>u.UserName == username);
            if (user == null) throw new Exception("User was not found");

            if (await usermeneger.Users.AnyAsync(u => u.UserName == userDto.Username)) 
                throw new Exception("Username is already exist");

            await usermeneger.UpdateAsync(mapper.Map(userDto, user));
        }

        public async Task DeleteAccountAsync(string username, string password)
        {
            var user=await usermeneger.Users.FirstOrDefaultAsync(u=>u.UserName==username);
            if (user == null) throw new Exception("Username or Password is incorrect");

            var result=await usermeneger.CheckPasswordAsync(user, password);
            if (!result) throw new Exception("Username or Password is incorrect");

            await usermeneger.DeleteAsync(user);

        }
    }
}
