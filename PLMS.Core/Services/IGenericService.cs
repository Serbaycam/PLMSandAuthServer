using System.Linq.Expressions;

namespace PLMS.Core.Services
{
    public interface IGenericService<TEntity,TContext> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
