using System.ComponentModel.DataAnnotations;

namespace AuthIdentity.Core.DTOs
{
    public class AuthIdentityUserLoginDto
    {
        public AuthIdentityUserLoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
