using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MockData.Repositories
{
    class FineFakeRepository : IRepositoryBase<Fine>, IFineRepository
    {
        private readonly List<Fine> _list;

        public FineFakeRepository()
        {
            _list = new List<Fine>
            {
                new Fine { Id = Guid.Parse("1581b92f-0501-4b5b-a962-e66a34639d00"), 
                    IdGpResult = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2"), 
                    Description = "desc1" },
                new Fine { Id = Guid.Parse("8d05bdf0-8712-48c9-840b-669778c8520c"), 
                    IdGpResult = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7"), 
                    Description = "desc2" },
                new Fine { Id = Guid.Parse("09a565b4-8f52-4110-9218-462967448625"), 
                    IdGpResult = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff"), 
                    Description = "desc3" }
            };
        }

        public Task<Fine> AddAsync(Fine entity)
        {
            entity.Id = Guid.Parse("d23e3da7-c36d-494a-ae48-83b15783dcc1");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Fine entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Fine>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Fine> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Fine entity)
        {
            return Task.FromResult(true);
        }
    }
}
