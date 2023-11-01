﻿using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using AuthIdentity.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Service.Services
{
    public class AuthIdentityMemberService : IAuthIdentityMemberService
    {
        private readonly UserManager<AuthIdentityUser> _userManager;
        private readonly SignInManager<AuthIdentityUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthIdentityMemberService(UserManager<AuthIdentityUser> userManager)
        {
            _userManager = userManager;
        }

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

        public async Task<(bool,string)> LoginAsync(AuthIdentityUserLoginDto authIdentityUserLoginDto)
        {
            AuthIdentityUser hasUser = await _userManager.FindByEmailAsync(authIdentityUserLoginDto.Email);
            if (hasUser == null)
                return (false,"User Not found");
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(hasUser,authIdentityUserLoginDto.Password,authIdentityUserLoginDto.RememberMe,false);
            if(!signInResult.Succeeded)
            {
                return (true,signInResult.ToString());
            }
            else
            {
                return (false,signInResult.ToString());
            }

        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
