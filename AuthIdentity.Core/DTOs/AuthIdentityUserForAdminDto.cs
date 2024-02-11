using AuthIdentity.Core.Entities;

namespace AuthIdentity.Core.DTOs
{
    public class AuthIdentityUserForAdminDto:AuthIdentityUser
    {
        public List<string> Roles { get; set; }
    }
}
