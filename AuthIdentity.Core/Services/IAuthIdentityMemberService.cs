using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Services
{
    public interface IAuthIdentityMemberService
	{

		Task<AuthIdentityUserDto> GetUserDtoByUserNameAsync(string userName);
		Task<AuthIdentityUser> GetUserByNameAsync(string userName);
		Task<(bool, string)> LoginAsync(AuthIdentityUserLoginDto authIdentityUserLoginDto);
		Task<bool> CheckPasswordAsync(AuthIdentityUser user,string password);
		Task<IdentityResult> ChangePasswordAsync(AuthIdentityUser user,string oldPassword,string newPassword);
		Task<IdentityResult> UpdateSecurityStampAsync(AuthIdentityUser user);
        Task LogoutAsync();
		public Task<(bool, IEnumerable<IdentityError>)> RegisterUserByUserDtoAsync(AuthIdentityUserRegisterDto authIdentityUserRegisterDto);
	}
}
