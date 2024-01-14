using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Services
{
    public interface IAuthIdentityRoleService
    {
        Task<IdentityResult> CreateRoleAsync(AuthIdentityRoleAddDto dto);
        Task<List<AuthIdentityRoleDto>> GetAllRolesAsync();
        Task<AuthIdentityRoleModifyDto> GetRoleByIdForModifyAsync(string roleId);
        Task<AuthIdentityRoleDeleteDto> GetRoleByIdForDeleteAsync(string roleId);
        Task<IdentityResult> ModifyRoleAsync(AuthIdentityRoleModifyDto dto);
        Task<IdentityResult> DeleteRoleAsync(AuthIdentityRoleDeleteDto dto);
    }
}
