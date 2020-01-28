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

        public async Task<T> GetById(Guid id)
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }

        public async Task<int> Create(T entity)
        {
            try
            {
                await RepositoryContext.Set<T>().AddAsync(entity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Update(T entity)
        {
            try
            {
                RepositoryContext.Set<T>().Update(entity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(T entity)
        {
            try
            {
                RepositoryContext.Set<T>().Remove(entity);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
