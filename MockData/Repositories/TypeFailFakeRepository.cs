using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class TypeFailFakeRepository : IRepositoryBase<TypeFail>, ITypeFailRepository
    {
        private readonly List<TypeFail> _list;

        public TypeFailFakeRepository()
        {
            _list = new List<TypeFail>
            {
                new TypeFail { Id = Guid.Parse("960930f1-d5f5-4119-bbee-3e1b869312de"), Name = "name 1"},
                new TypeFail { Id = Guid.Parse("2d433d3c-d70d-4e65-8149-d094482459b6"), Name = "name 2"},
                new TypeFail { Id = Guid.Parse("c5134f9c-3801-467a-97e1-f8bd6f8cf10b"), Name = "name 3"}
            };
        }

        public Task<IEnumerable<TypeFail>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<TypeFail> AddAsync(TypeFail entity)
        {
            entity.Id = Guid.Parse("bcfdb7e4-b0f6-4b6a-b4ed-2b63014b648c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<TypeFail> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(TypeFail entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(TypeFail entity)
        {
            return Task.FromResult(true);
        }
    }
}
