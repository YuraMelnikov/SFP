using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class TypeCalculateFakeRepository : IRepositoryBase<TypeCalculate>, ITypeCalculateRepository
    {
        private readonly List<TypeCalculate> _list;

        public TypeCalculateFakeRepository()
        {
            _list = new List<TypeCalculate>
            {
                new TypeCalculate { Id = Guid.Parse("ea399aa9-d11f-45db-8a8b-528fe554e396"), 
                    Description = "desc1", 
                    Name = "name1" },
                new TypeCalculate { Id = Guid.Parse("2bb8cdc0-4eb9-46ea-9e37-668dc692edc3"), 
                    Description = "desc2", 
                    Name = "name2" },
                new TypeCalculate { Id = Guid.Parse("da2b9101-7a02-4b64-a0c7-126ad1ed6845"), 
                    Description = "desc3", 
                    Name = "name3" }
            };
        }

        public Task<IEnumerable<TypeCalculate>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<TypeCalculate> AddAsync(TypeCalculate entity)
        {
            entity.Id = Guid.Parse("bcfdb7e4-b0f6-4b6a-b4ed-2b63014b648c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<TypeCalculate> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(TypeCalculate entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(TypeCalculate entity)
        {
            return Task.FromResult(true);
        }
    }
}
