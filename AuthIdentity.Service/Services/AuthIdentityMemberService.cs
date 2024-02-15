using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using AuthIdentity.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Service.Services
{
    public class AuthIdentityMemberService(UserManager<AuthIdentityUser> userManager, SignInManager<AuthIdentityUser> signInManager, IMapper mapper) : IAuthIdentityMemberService
    {
        private readonly UserManager<AuthIdentityUser> _userManager = userManager;
        private readonly SignInManager<AuthIdentityUser> _signInManager = signInManager;
        private readonly IMapper _mapper = mapper;

        public async Task<AuthIdentityUserDto> GetUserDtoByUserNameAsync(string userName)
        {
            AuthIdentityUser currentUser = (await _userManager.FindByNameAsync(userName));
            AuthIdentityUserDto userDto = _mapper.Map<AuthIdentityUserDto>(currentUser);
            return userDto;
        }

        public async Task<(bool, IEnumerable<IdentityError>)> RegisterUserByUserDtoAsync(AuthIdentityUserRegisterDto authIdentityUserRegisterDto)
        {
            IdentityResult identityResult = await _userManager.CreateAsync(
                new AuthIdentityUser
                {
                    Email = authIdentityUserRegisterDto.Email,
                    Name = authIdentityUserRegisterDto.Name,
                    Surname = authIdentityUserRegisterDto.Surname,
                    UserName = authIdentityUserRegisterDto.UserName,

                }, authIdentityUserRegisterDto.Password);
            if (!identityResult.Succeeded)
            {
                return (false, identityResult.Errors);
            }
            else
            {
                return (true, null);
            }

        }

        public async Task<(bool, string)> LoginAsync(AuthIdentityUserLoginDto authIdentityUserLoginDto)
        {
            AuthIdentityUser hasUser = await _userManager.FindByEmailAsync(authIdentityUserLoginDto.Email);
            if (hasUser == null)
                return (false, "User Not found");
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(hasUser, authIdentityUserLoginDto.Password, authIdentityUserLoginDto.RememberMe, true);
            if (!signInResult.Succeeded)
            {
                return (false, signInResult.ToString());
            }
            else
            {
                return (true, signInResult.ToString());
            }

        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthIdentityUser> GetUserByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> CheckPasswordAsync(AuthIdentityUser authIdentityUser, string password)
        {

            return await _userManager.CheckPasswordAsync(authIdentityUser, password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(AuthIdentityUser authIdentityUser, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(authIdentityUser, oldPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateSecurityStampAsync(AuthIdentityUser authIdentityUser)
        {
            return await _userManager.UpdateSecurityStampAsync(authIdentityUser);
        }

        public async Task<IdentityResult> UpdateUserByUserAsync(AuthIdentityUser authIdentityUser)
        {
            return await _userManager.UpdateAsync(authIdentityUser);
        }

        public async Task<IdentityResult> DeleteUserByUserAsync(AuthIdentityUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<AuthIdentityUser> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
