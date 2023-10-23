using System.ComponentModel.DataAnnotations;

namespace AuthIdentity.Core.DTOs
{
    public class RegisterAuthIdentityUserDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string PasswordMatch { get; set; }
    }
}
