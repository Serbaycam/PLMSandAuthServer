using AuthIdentity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthIdentity.Repository.Configurations
{
    public class AuthIdentityRoleConfiguration : IEntityTypeConfiguration<AuthIdentityRole>
    {
        public void Configure(EntityTypeBuilder<AuthIdentityRole> builder)
        {
            builder.HasData(new AuthIdentityRole
            {
                Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                Name = "MasterAdmin",
                NormalizedName = "MASTERADMIN",
                ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
            });
        }
    }
}
