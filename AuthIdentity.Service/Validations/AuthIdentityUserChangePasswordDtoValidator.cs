using AuthIdentity.Core.DTOs;
using FluentValidation;

namespace AuthIdentity.Service.Validations
{
    public class AuthIdentityUserChangePasswordDtoValidator: AbstractValidator<AuthIdentityUserChangePasswordDto>
    {
        public AuthIdentityUserChangePasswordDtoValidator()
        {
            RuleFor(x => x.OldPassword).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.NewPassword).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} cannot be empty").MinimumLength(3).WithMessage("{PropertyName} must be a minimum 3 character");
            RuleFor(x => x.PasswordMatch).NotNull().WithMessage("{PropertyName} is required.").Equal(x => x.NewPassword).WithMessage("Passwords must be same").NotEmpty().WithMessage("{PropertyName} cannot be empty").MinimumLength(3).WithMessage("{PropertyName} must be a minimum 3 character");

        }
    }
}
