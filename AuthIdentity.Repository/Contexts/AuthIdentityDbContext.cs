using AuthIdentity.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthIdentity.Repository.Contexts
{
    public class AuthIdentityDbContext(DbContextOptions<AuthIdentityDbContext> options) : IdentityDbContext<AuthIdentityUser, AuthIdentityRole, string>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
