using Microsoft.EntityFrameworkCore;
using PLMS.Core.UnitOfWork;

namespace PLMS.Repository.UnitOfWork
{
    public class UnitOfWork<TContext>(TContext context) : IUnitOfWork<TContext>
        where TContext : DbContext
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
