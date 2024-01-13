using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Services
{
    public interface IAuthIdentityRoleService
    {
        Task<IdentityResult> CreateRoleAsync(AuthIdentityRoleAddDto dto);
        Task<IList<AuthIdentityRole>> GetAllRolesAsync();
        Task<AuthIdentityRoleModifyDto> GetRoleByIdAsync(string roleId);
        Task<IdentityResult> ModifyRoleAsync(AuthIdentityRoleModifyDto dto);
    }
}
