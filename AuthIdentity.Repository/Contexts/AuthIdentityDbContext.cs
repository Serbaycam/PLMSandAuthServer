using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentity.Repository.Contexts
{
    public class AuthIdentityDbContext:IdentityDbContext<AuthIdentityUser,AuthIdentityRole,string>
    {
        public AuthIdentityDbContext(DbContextOptions<AuthIdentityDbContext> options):base(options)
        {
            
        }
    }
}
