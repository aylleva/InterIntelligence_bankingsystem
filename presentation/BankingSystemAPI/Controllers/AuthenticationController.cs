using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BankingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService service;
        private readonly IValidator<CreateAccountDto> validator;

        public AuthenticationController(IAuthenticationService service, IValidator<CreateAccountDto> validator)
        {
            this.service = service;
            this.validator = validator;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto)
        {
            var validate = await validator.ValidateAsync(dto);

            if (!validate.IsValid)
            {
                foreach(var error in validate.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
          
            await service.CreateAccountAsync(dto);

            return Created();
        }

        [HttpPost("[Action]")]

        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await service.LoginAsync(dto));
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> UpdateAccount(string username,[FromForm]UpdateAccountDto userDto)
        {
            await service.UpdateAccountAsync(username, userDto);
            return NoContent();
        }

        [HttpDelete("[Action]")]
        public async Task<IActionResult> DeleteAccount(string username,string password)
        {
            await service.DeleteAccountAsync(username, password);
            return NoContent();
        }
    }
}
