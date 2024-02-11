using AuthIdentity.Core.DTOs;

namespace AuthIdentity.Core.Services
{
    public interface IAuthIdentityUserService
    {
        Task<List<AuthIdentityUserForAdminDto>> GetAllUsersAsync();
    }
}
