using BankingSystem.Application.DTOs;
using FluentValidation;


namespace BankingSystem.Application.FluentValidation
{
    public class AccoutValidator:AbstractValidator<CreateAccountDto>
    {
        public AccoutValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name Required")
              .MinimumLength(3)
                    .WithMessage("Name must exist min 3 symbols")
               .MaximumLength(20)
                    .WithMessage("Name must exist max 20 symbols")
                .Matches(@"^[A-Za-z]*$")
                        .WithMessage("Wrong Type");

            RuleFor(x => x.Surname).NotEmpty()
               .WithMessage("Surname Required")
             .MinimumLength(3)
                   .WithMessage("Surname must exist min 3 symbols")
              .MaximumLength(40)
                   .WithMessage("Surname must exist max 40 symbols")
               .Matches(@"^[A-Za-z]*$")
                       .WithMessage("Wrong Type");

            RuleFor(x => x.Username).NotEmpty()
               .WithMessage("UserName Required")
             .MinimumLength(3)
                   .WithMessage("UserName must exist min 3 symbols")
              .MaximumLength(256)
                   .WithMessage("UserName must exist max 256 symbols")
               .Matches(@"^[A-Za-z0-9_.]*$")
                       .WithMessage("Wrong Type");

            RuleFor(x => x.Email).NotEmpty()
               .WithMessage("Email Required")
             .MinimumLength(3)
                   .WithMessage("Email must exist min 3 symbols")
              .MaximumLength(256)
                   .WithMessage("Email must exist max 256 symbols")
               .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                       .WithMessage("Wrong Type");

            RuleFor(x => x.Password).NotEmpty()
               .WithMessage("Password Required")
             .MinimumLength(8)
                   .WithMessage("Password must exist min 8 symbols")
               .Must(CheckPassword)
                    .WithMessage("Wrong Type!");

         
        }
        private bool CheckPassword(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]) || Char.IsUpper(password[i]) || Char.IsLower(password[i])) return true;
            }
            return false;
        }

    }
}

