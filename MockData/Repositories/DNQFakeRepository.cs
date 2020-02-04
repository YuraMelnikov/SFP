using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class DNQFakeRepository : IRepositoryBase<DNQ>, IDNQRepository
    {
        private readonly List<DNQ> _list;

        public DNQFakeRepository()
        {
            _list = new List<DNQ>
            {
                new DNQ  { Id = Guid.Parse("35667513-0a9d-495d-9b7c-b35cebdb18bb"),
                    Description = "desc1", 
                    IdGpResult = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2"), 
                    IdTypeDnq = Guid.Parse("ba84700c-9ce2-4438-9e16-c10e1eabb963") },
                new DNQ  { Id = Guid.Parse("5726c484-bc62-4f20-98e9-4aef30aa50b4"),
                    Description = "desc2",
                    IdGpResult = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7"),
                    IdTypeDnq = Guid.Parse("b139d7e6-a19e-4ee8-870c-d0478cda0ea2") },
                new DNQ  { Id = Guid.Parse("f308baa4-b8d5-4aef-ba25-8c4fd0fc7b51"),
                    Description = "desc3",
                    IdGpResult = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff"),
                    IdTypeDnq = Guid.Parse("de1dd752-d74b-4d8d-8814-bc1e4561c352") }
            };
        }

        public Task<IEnumerable<DNQ>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<DNQ> AddAsync(DNQ entity)
        {
            entity.Id = Guid.Parse("bcfdb7e4-b0f6-4b6a-b4ed-2b63014b648c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<DNQ> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(DNQ entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(DNQ entity)
        {
            return Task.FromResult(true);
        }
    }
}
