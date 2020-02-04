using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class TypeDNQFakeRepository : IRepositoryBase<TypeDNQ>, ITypeDNQRepository
    {
        private readonly List<TypeDNQ> _list;

        public TypeDNQFakeRepository()
        {
            _list = new List<TypeDNQ>
            {
                new TypeDNQ  { Id = Guid.Parse("ba84700c-9ce2-4438-9e16-c10e1eabb963"), 
                    Name = "name1" },
                new TypeDNQ  { Id = Guid.Parse("b139d7e6-a19e-4ee8-870c-d0478cda0ea2"),
                    Name = "name2" },
                new TypeDNQ  { Id = Guid.Parse("de1dd752-d74b-4d8d-8814-bc1e4561c352"),
                    Name = "name3" }
            };
        }

        public Task<IEnumerable<TypeDNQ>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<TypeDNQ> AddAsync(TypeDNQ entity)
        {
            entity.Id = Guid.Parse("bcfdb7e4-b0f6-4b6a-b4ed-2b63014b648c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<TypeDNQ> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(TypeDNQ entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(TypeDNQ entity)
        {
            return Task.FromResult(true);
        }
    }
}
