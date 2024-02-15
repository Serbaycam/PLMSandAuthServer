using AuthIdentity.Core.Entities;
using AuthIdentity.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Service.Services
{
    public class AuthIdentityRoleAssignService(UserManager<AuthIdentityUser> userManager,RoleManager<AuthIdentityRole> roleManager,IMapper mapper) : IAuthIdentityRoleAssignService
    {
        private readonly UserManager<AuthIdentityUser> _userManager = userManager;
        private readonly RoleManager<AuthIdentityRole> _roleManager = roleManager;
        private readonly IMapper _mapper = mapper;

       
    }
}
