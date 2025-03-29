using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Services;
using BankingSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace BankingSystem.Infrastructure.Implementations
{
    internal class TokenHandlerService : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandlerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public TokenHandlerDto CreateToken(Account user, int minutes)
        {
            IEnumerable<Claim> claims = new List<Claim>() { 
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.GivenName, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
            };

            SymmetricSecurityKey securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:secretkey"]));

            SigningCredentials signingCredentials=new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securitytoken = new JwtSecurityToken(
                issuer: configuration["JWT:issuer"],
                audience: configuration["JWT:audience"],
                expires:DateTime.UtcNow.AddMinutes(minutes),
                notBefore:DateTime.UtcNow,
                claims:claims,
                signingCredentials:signingCredentials
                );

            JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
            string token= tokenhandler.WriteToken(securitytoken);

            return new TokenHandlerDto(token, user.UserName, securitytoken.ValidTo);
          
        }
    }
}

