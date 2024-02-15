using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Services
{
    public interface IAuthIdentityMemberService
    {

        Task<AuthIdentityUserDto> GetUserDtoByUserNameAsync(string userName);
        Task<AuthIdentityUser> GetUserByUserNameAsync(string userName);
        Task<(bool, string)> LoginAsync(AuthIdentityUserLoginDto authIdentityUserLoginDto);
        Task<bool> CheckPasswordAsync(AuthIdentityUser authIdentityUser, string password);
        Task<IdentityResult> ChangePasswordAsync(AuthIdentityUser authIdentityUser, string oldPassword, string newPassword);
        Task<IdentityResult> UpdateSecurityStampAsync(AuthIdentityUser authIdentityUser);
        Task LogoutAsync();
        Task<IdentityResult> UpdateUserByUserAsync(AuthIdentityUser authIdentityUser);
        Task<(bool, IEnumerable<IdentityError>)> RegisterUserByUserDtoAsync(AuthIdentityUserRegisterDto authIdentityUserRegisterDto);
        Task<IdentityResult> DeleteUserByUserAsync(AuthIdentityUser user);
        Task<AuthIdentityUser> GetUserByIdAsync(string id);
    }
}
