using AuthIdentityJWT.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentityJWT.Data.UnitOfWork
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly DbContext _context = context;

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
