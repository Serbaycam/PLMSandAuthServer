using AuthIdentity.Core.DTOs;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Services
{
    public interface IAuthIdentityRoleService
    {
        Task<IdentityResult> CreateRoleAsync(AuthIdentityRoleAddDto dto); 
    }
}
