using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<int> Create(T entity);
        Task Update(T entity);
        Task<int> Delete(T entity);
    }
}
