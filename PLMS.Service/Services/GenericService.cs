﻿using Microsoft.EntityFrameworkCore;
using PLMS.Core.Repositories;
using PLMS.Core.Services;
using PLMS.Core.UnitOfWork;
using PLMS.Service.Exceptions;
using System.Linq.Expressions;

namespace PLMS.Service.Services
{
    public class GenericService<TEntity,TContext>:IGenericService<TEntity,TContext>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly IGenericRepository<TEntity, TContext> _genericRepository;
        private readonly IUnitOfWork<TContext> _unitOfWork;

        public GenericService(IGenericRepository<TEntity, TContext> genericRepository, IUnitOfWork<TContext> unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _genericRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _genericRepository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _genericRepository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public void Update(TEntity entity)
        {
            _genericRepository.Update(entity);
            _unitOfWork.Commit();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
           _genericRepository.UpdateRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var hasEntity = await _genericRepository.WhereAsync(predicate);
            if (hasEntity == null)
                throw new NotFoundException($"{typeof(TEntity).Name} not found");
            return hasEntity;
        }
    }
}
