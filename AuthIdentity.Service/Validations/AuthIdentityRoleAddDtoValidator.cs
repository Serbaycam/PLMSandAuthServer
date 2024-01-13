using AuthIdentity.Core.DTOs;
using FluentValidation;

namespace AuthIdentity.Service.Validations
{
    public class AuthIdentityRoleAddDtoValidator:AbstractValidator<AuthIdentityRoleAddDto>
    {
        public AuthIdentityRoleAddDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} cannot be empty").MaximumLength(60).WithMessage("{PropertyName} must be maximum 60 character").MinimumLength(5).WithMessage("{PropertyName} must be minimum 5 character");

        }
    }
}
