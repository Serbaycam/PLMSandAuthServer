using AuthIdentity.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentity.Repository.UnitOfWork
{
    public class AuthIdentityUnitOfWork<TContext>:IAuthIdentityUnitOfWork<TContext>
        where TContext : DbContext
    {
        private readonly DbContext _context;

        public AuthIdentityUnitOfWork(DbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
