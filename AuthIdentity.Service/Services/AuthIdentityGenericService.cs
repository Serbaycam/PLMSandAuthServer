using AuthIdentity.Core.Services;
using AuthIdentity.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthIdentity.Service.Services
{
    public class AuthIdentityGenericService<TEntity, TContext>(IAuthIdentityGenericService<TEntity, TContext> genericRepository, IAuthIdentityUnitOfWork<TContext> unitOfWork) : IAuthIdentityGenericService<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly IAuthIdentityGenericService<TEntity, TContext> _genericRepository = genericRepository;
        private readonly IAuthIdentityUnitOfWork<TContext> _unitOfWork = unitOfWork;

        public async Task AddAsync(TEntity entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _genericRepository.Remove(entity);
            _unitOfWork.Commit();
        }



        public void Update(TEntity entity)
        {
            _genericRepository.Update(entity);
            _unitOfWork.Commit();
        }



        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _genericRepository.WhereAsync(predicate);
        }
    }
}
