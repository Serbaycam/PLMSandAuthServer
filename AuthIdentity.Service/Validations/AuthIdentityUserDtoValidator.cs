using AuthIdentity.Core.DTOs;
using FluentValidation;

namespace AuthIdentity.Service.Validations
{
    public class AuthIdentityUserDtoValidator:AbstractValidator<AuthIdentityUserDto>
    {
        public AuthIdentityUserDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").MinimumLength(2).WithMessage("{PropertyName} can be 2 character min.").MaximumLength(50).WithMessage("{PropertyName} can be 50 characters max.").NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required.").MinimumLength(2).WithMessage("{PropertyName} can be 2 character min.").MaximumLength(50).WithMessage("{PropertyName} can be 50 characters max.").NotEmpty().WithMessage("{PropertyName} cannot be empty");

        }
    }
}
