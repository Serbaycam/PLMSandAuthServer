using AuthIdentity.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthIdentity.Repository.Repositories
{
    public class AuthIdentityGenericRepository<TEntity, TContext>(TContext context) : IAuthIdentityGenericRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext _context = context;
        private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }



        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }



        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }
    }

}
