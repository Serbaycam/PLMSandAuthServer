﻿using AuthIdentity.Core.DTOs;
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

        public Task<IdentityResult> CreateRoleAsync(AuthIdentityRoleAddDto dto)
        {
            return _roleManager.CreateAsync(_mapper.Map<AuthIdentityRole>(dto));
        }

        public async Task<IdentityResult> DeleteRoleAsync(AuthIdentityRoleDeleteDto dto)
        {
            return await _roleManager.DeleteAsync(_mapper.Map<AuthIdentityRole>(dto));
        }

        public async Task<List<AuthIdentityRoleDto>> GetAllRolesAsync()
        {
            return _mapper.Map<List<AuthIdentityRoleDto>>(await _roleManager.Roles.AsNoTracking().ToListAsync());
        }

        public async Task<AuthIdentityRoleModifyDto> GetRoleByIdForModifyAsync(string roleId)
        {
            return _mapper.Map<AuthIdentityRoleModifyDto>(await _roleManager.FindByIdAsync(roleId));
        }
        public async Task<AuthIdentityRoleDeleteDto> GetRoleByIdForDeleteAsync(string roleId)
        {
            return _mapper.Map<AuthIdentityRoleDeleteDto>(await _roleManager.FindByIdAsync(roleId));
        }

        public async Task<IdentityResult> ModifyRoleAsync(AuthIdentityRoleModifyDto dto)
        {
            return await _roleManager.UpdateAsync(_mapper.Map<AuthIdentityRole>(dto));
        }
    }
}
