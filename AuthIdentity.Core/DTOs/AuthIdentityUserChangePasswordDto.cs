namespace AuthIdentity.Core.DTOs
{
    public class AuthIdentityUserChangePasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string PasswordMatch { get; set; }
    }
}
