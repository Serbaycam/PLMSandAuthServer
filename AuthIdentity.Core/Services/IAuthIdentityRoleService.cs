using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Services
{
    public interface IAuthIdentityRoleService
    {
        Task<IdentityResult> CreateRoleAsync(AuthIdentityRoleDto dto);
        Task<List<AuthIdentityRoleDto>> GetRoleDtoListAllRolesAsync();
        Task<AuthIdentityRoleDto> GetRoleDtoByIdAsync(string roleId);
        Task<IdentityResult> ModifyRoleAsync(AuthIdentityRoleDto dto);
        Task<IdentityResult> DeleteRoleAsync(AuthIdentityRoleDto dto);
    }
}
