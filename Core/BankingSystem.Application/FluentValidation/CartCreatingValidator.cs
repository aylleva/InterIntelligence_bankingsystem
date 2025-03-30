using BankingSystem.Application.DTOs.Transaction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application.FluentValidation
{
    public class CartCreatingValidator:AbstractValidator<CreateCartDto>
    {
        public CartCreatingValidator()
        {
            RuleFor(x=>x.CartNumber)
                .NotEmpty()
                    .WithMessage("Cart Number is Required")
                .Matches(@"^[0-9]*$")
                    .WithMessage("Wrong Type!Only Numbers")
                  .MinimumLength(16)
                    .WithMessage("Number must exist min 16 digits")
               .MaximumLength(19)
                    .WithMessage("Number must exist max 19 digits");
     
        }
    }
}
