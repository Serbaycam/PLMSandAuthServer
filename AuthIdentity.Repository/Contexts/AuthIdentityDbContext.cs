using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentity.Repository.Contexts
{
    public class AuthIdentityDbContext(DbContextOptions<AuthIdentityDbContext> options) : IdentityDbContext<AuthIdentityUser,AuthIdentityRole,string>(options)
    {
    }
}
