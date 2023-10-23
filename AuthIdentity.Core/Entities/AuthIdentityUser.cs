using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Entities
{
    public class AuthIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
