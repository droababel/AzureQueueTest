﻿using System.Linq.Expressions;

namespace InvoiceProcess.Domain.Core.Repositories
{
    public interface IRepositoryBase<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAllAsync(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsyncWithTracking(int id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
