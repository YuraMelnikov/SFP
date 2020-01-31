using Contracts;
using Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await RepositoryContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            _ = RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            await RepositoryContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            await RepositoryContext.SaveChangesAsync();
            return true;
        }
    }
}
