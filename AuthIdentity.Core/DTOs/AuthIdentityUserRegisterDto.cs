using System.ComponentModel.DataAnnotations;

namespace AuthIdentity.Core.DTOs
{
    public class AuthIdentityUserRegisterDto
    {
        public AuthIdentityUserRegisterDto()
        {

        }
        public AuthIdentityUserRegisterDto(string name, string surName, string email, string password, string passwordMatch)
        {
            Name = name;
            Surname = surName;
            Email = email;
            Password = password;
            PasswordMatch = passwordMatch;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string PasswordMatch { get; set; }
        public string UserName => Name+" "+Surname;
    }
}
