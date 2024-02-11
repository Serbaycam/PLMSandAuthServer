using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using AuthIdentity.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentity.Service.Services
{
    public class AuthIdentityUserService(UserManager<AuthIdentityUser> userManager, IMapper mapper) : IAuthIdentityUserService
    {
        private readonly UserManager<AuthIdentityUser> _userManager = userManager;
        private readonly IMapper _mapper = mapper;


        public async Task<List<AuthIdentityUserForAdminDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.AsNoTracking().ToListAsync();
            var userList = new List<AuthIdentityUserForAdminDto>();

            foreach (var u in users)
            {
                var roles = await _userManager.GetRolesAsync(u);
                var userDto = new AuthIdentityUserForAdminDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    EmailConfirmed = u.EmailConfirmed,
                    Roles = roles.ToList()
                };
                userList.Add(userDto);
            }

            return userList;
        }
    }
}
