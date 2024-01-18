using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentity.Repository.Configurations
{
    public class AuthIdentityUserConfiguration : IEntityTypeConfiguration<AuthIdentityUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuthIdentityUser> builder)
        {
            PasswordHasher<AuthIdentityUser> passwordHasher = new PasswordHasher<AuthIdentityUser>();
            builder.HasData(new AuthIdentityUser
            {
                Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                Name = "MasterAdmin",
                Surname = "MasterAdmin",
                UserName = "MasterAdmin",
                NormalizedUserName = "MASTERADMIN",
                Email = "Masteradmin@plms.local",
                NormalizedEmail = "MASTERADMIN@PLMS.LOCAL",
                ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, "K5yxatfnu+"),
            });
        }
    }
}
