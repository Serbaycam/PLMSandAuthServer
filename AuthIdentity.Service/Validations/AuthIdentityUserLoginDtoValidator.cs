using AuthIdentity.Core.DTOs;
using FluentValidation;

namespace AuthIdentity.Service.Validations
{
    public class AuthIdentityUserLoginDtoValidator : AbstractValidator<AuthIdentityUserLoginDto>
    {
        public AuthIdentityUserLoginDtoValidator()
        {

            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
