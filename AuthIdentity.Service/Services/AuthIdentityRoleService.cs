using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using AuthIdentity.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Service.Services
{
    public class AuthIdentityRoleService(IMapper mapper, RoleManager<AuthIdentityRole> roleManager) : IAuthIdentityRoleService
    {
        private readonly RoleManager<AuthIdentityRole> _roleManager = roleManager;
        private readonly IMapper _mapper = mapper;

        public Task<IdentityResult> CreateRoleAsync(AuthIdentityRoleAddDto dto)
        {
            AuthIdentityRole role = _mapper.Map<AuthIdentityRole>(dto);
            return _roleManager.CreateAsync(role);
        }
    }
}
