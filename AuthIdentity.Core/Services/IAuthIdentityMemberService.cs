﻿using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Services
{
	public interface IAuthIdentityMemberService
	{

		Task<AuthIdentityUserDto> GetUserDtoByUserNameAsync(string userName);
		Task Logout();
		public Task<(bool, IEnumerable<IdentityError>)> RegisterUserByUserDtoAsync(AuthIdentityUserRegisterDto authIdentityUserRegisterDto);
	}
}