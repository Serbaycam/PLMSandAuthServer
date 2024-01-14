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
            return _mapper.Map<List<AuthIdentityUserForAdminDto>>(await _userManager.Users.AsNoTracking().ToListAsync());
        }
    }
}
