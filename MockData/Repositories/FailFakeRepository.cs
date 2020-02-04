using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class FailFakeRepository : IRepositoryBase<Fail>, IFailRepository
    {
        private readonly List<Fail> _list;

        public FailFakeRepository()
        {
            _list = new List<Fail>
            {
                new Fail { Id = Guid.Parse("407f3944-1212-4cd2-be55-9a5049df9966"), 
                    IdTypeFail = Guid.Parse("960930f1-d5f5-4119-bbee-3e1b869312de"), 
                    IdGpResult = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2"), 
                    Description = "desc1"},
                new Fail { Id = Guid.Parse("60e0d3a9-df41-4d2b-b5d5-bb93864279ec"),
                    IdTypeFail = Guid.Parse("960930f1-d5f5-4119-bbee-3e1b869312de"),
                    IdGpResult = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7"),
                    Description = "desc2"},
                new Fail { Id = Guid.Parse("06492f34-9220-46e5-b9bc-73580f0349de"),
                    IdTypeFail = Guid.Parse("960930f1-d5f5-4119-bbee-3e1b869312de"),
                    IdGpResult = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff"),
                    Description = "desc3"},
            };
        }

        public Task<IEnumerable<Fail>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<Fail> AddAsync(Fail entity)
        {
            entity.Id = Guid.Parse("bcfdb7e4-b0f6-4b6a-b4ed-2b63014b648c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<Fail> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(Fail entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(Fail entity)
        {
            return Task.FromResult(true);
        }
    }
}
