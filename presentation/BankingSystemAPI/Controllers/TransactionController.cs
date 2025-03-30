using BankingSystem.Application.DTOs.Transaction;
using BankingSystem.Application.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService service;
        private readonly IValidator<CreateCartDto> cartvalidator;
        private readonly IValidator<TransactMoneyDto> transactionvalidator;

        public TransactionController(ITransactionService service,IValidator<CreateCartDto> cartvalidator,
            IValidator<TransactMoneyDto> transactionvalidator)
        {
            this.service = service;
            this.cartvalidator = cartvalidator;
            this.transactionvalidator = transactionvalidator;
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetCarts(string userId)
        {
           return Ok(await service.GetCarts(userId));
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> AddCart(CreateCartDto cartDto)
        {
            var validate=await cartvalidator.ValidateAsync(cartDto);
            if (!validate.IsValid)
            {
              foreach(var error in validate.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
              return BadRequest(ModelState);
            }
            await service.CreateCartAsync(cartDto);
            return Created();
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> TransactMoney(TransactMoneyDto moneyDto)
        {
            var validate = await transactionvalidator.ValidateAsync(moneyDto);
            if (!validate.IsValid)
            {
                foreach (var error in validate.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            await service.TransactMoneyAsync(moneyDto);
            return Ok();
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> IncreaseBalance(ChangeBalanceDto balanceDto)
        {
            await service.IncreaseBalanceAsync(balanceDto);
            return Ok();
        }

      

    }
}
