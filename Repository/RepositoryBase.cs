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

        public async Task<IEnumerable<T>> GetAll()
        {
            return await RepositoryContext.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            return await RepositoryContext.Set<T>().Add(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await RepositoryContext.Set<T>().Update(entity);
        }

        public async Task<T> Delete(T entity)
        {
            return await RepositoryContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetById(Guid id)
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }
    }
}
