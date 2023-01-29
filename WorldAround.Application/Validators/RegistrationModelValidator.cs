using FluentValidation;
using WorldAround.Domain.Models.Identity;

namespace WorldAround.Application.Validators
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
