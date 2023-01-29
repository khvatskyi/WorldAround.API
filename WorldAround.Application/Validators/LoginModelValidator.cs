using FluentValidation;
using WorldAround.Domain.Models.Identity;

namespace WorldAround.Application.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
