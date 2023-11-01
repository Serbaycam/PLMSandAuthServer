using System.ComponentModel.DataAnnotations;

namespace AuthIdentity.Core.DTOs
{
    public class AuthIdentityUserLoginDto
    {
        public AuthIdentityUserLoginDto()
        {
            
        }
        public AuthIdentityUserLoginDto(string email, string password, bool rememberMe)
        {
            Email = email;
            Password = password;
            RememberMe = rememberMe;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;
    }
}
