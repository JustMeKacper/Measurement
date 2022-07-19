using FluentValidation;
using Measurement.Entities;
using System.Linq;

namespace Measurement.Models.Validators
{
    public class RegisterUserDtoValidator:AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(DataContext dataContext)
        {
            RuleFor(x=>x.Email)
                .NotEmpty()
                .EmailAddress();


            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);


            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var EmailInUse = dataContext.Users.Any(u => u.Email == value);
                if (EmailInUse)
                    context.AddFailure("Email", "This email is taken");
            });
        }


    }
}
