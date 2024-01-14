using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using AuthIdentity.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentity.Service.Services
{
    public class AuthIdentityRoleService(IMapper mapper, RoleManager<AuthIdentityRole> roleManager) : IAuthIdentityRoleService
    {
        private readonly RoleManager<AuthIdentityRole> _roleManager = roleManager;
        private readonly IMapper _mapper = mapper;

        public Task<IdentityResult> CreateRoleAsync(AuthIdentityRoleDto dto)
        {
            AuthIdentityRole role = new AuthIdentityRole { Name = dto.Name };
            return _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(AuthIdentityRoleDto dto)
        {
            AuthIdentityRole role = await _roleManager.FindByIdAsync(dto.Id);
            return await _roleManager.DeleteAsync(role);
        }
        public async Task<IdentityResult> ModifyRoleAsync(AuthIdentityRoleDto dto)
        {
            AuthIdentityRole role = await _roleManager.FindByIdAsync(dto.Id);
            role.Name = dto.Name;
            return await _roleManager.UpdateAsync(role);
        }

        public async Task<List<AuthIdentityRoleDto>> GetRoleDtoListAllRolesAsync()
        {
            return _mapper.Map<List<AuthIdentityRoleDto>>(await _roleManager.Roles.AsNoTracking().ToListAsync());
        }

        public async Task<AuthIdentityRoleDto> GetRoleDtoByIdAsync(string roleId)
        {
            return _mapper.Map<AuthIdentityRoleDto>(await _roleManager.FindByIdAsync(roleId));
        }


    }
}
