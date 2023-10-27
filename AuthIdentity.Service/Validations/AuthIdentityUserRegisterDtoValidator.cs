using AuthIdentity.Core.DTOs;
using FluentValidation;

namespace AuthIdentity.Service.Validations
{
    public class AuthIdentityUserRegisterDtoValidator : AbstractValidator<AuthIdentityUserRegisterDto>
    {
        public AuthIdentityUserRegisterDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").MinimumLength(2).WithMessage("{PropertyName} can be 2 character min.").MaximumLength(50).WithMessage("{PropertyName} can be 50 characters max.").NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required.").MinimumLength(2).WithMessage("{PropertyName} can be 2 character min.").MaximumLength(50).WithMessage("{PropertyName} can be 50 characters max.").NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required.").Matches(x=>x.PasswordMatch).WithMessage("Passwords must be same").NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.PasswordMatch).NotNull().WithMessage("{PropertyName} is required.").Matches(x => x.Password).WithMessage("Passwords must be same").NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
