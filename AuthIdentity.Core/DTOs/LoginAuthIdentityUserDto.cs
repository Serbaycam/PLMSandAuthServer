using System.ComponentModel.DataAnnotations;

namespace AuthIdentity.Core.DTOs
{
    public class LoginAuthIdentityUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
