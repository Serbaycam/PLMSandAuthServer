﻿using System.Linq.Expressions;

namespace AuthIdentity.Core.Repositories
{
    public interface IAuthIdentityGenericRepository<TEntity, TContext> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
