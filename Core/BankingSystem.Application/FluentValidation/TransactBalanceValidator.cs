using BankingSystem.Application.DTOs.Transaction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.FluentValidation
{
    public class TransactBalanceValidator:AbstractValidator<TransactMoneyDto>
    {
        public TransactBalanceValidator()
        {
            RuleFor(x => x.CartNumberFrom)
               .NotEmpty()
                   .WithMessage("Cart Number is Required")
               .Matches(@"^[0-9]*$")
                   .WithMessage("Wrong Type!Only Numbers")
                 .MinimumLength(16)
                   .WithMessage("Number must exist min 16 digits")
              .MaximumLength(19)
                   .WithMessage("Number must exist max 19 digits");
            RuleFor(x => x.SecondCartNumberTo)
             .NotEmpty()
                 .WithMessage("Cart Number is Required")
             .Matches(@"^[0-9]*$")
                 .WithMessage("Wrong Type!Only Numbers")
               .MinimumLength(16)
                 .WithMessage("Number must exist min 16 digits")
            .MaximumLength(19)
                 .WithMessage("Number must exist max 19 digits");

            RuleFor(x => x.Balance)
               .NotEmpty()
                   .WithMessage("Balance is Required");
            RuleFor(x => x.UserId)
              .NotEmpty()
                  .WithMessage("Balance is Required");
        }
    }
}
