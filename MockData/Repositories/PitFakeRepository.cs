using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MockData.Repositories
{
    public class PitFakeRepository : IRepositoryBase<Pit>, IPitRepository
    {
        private readonly List<Pit> _list;

        public PitFakeRepository()
        {
            _list = new List<Pit>
            {
                new Pit { Id = Guid.Parse("3de57cd3-5780-4b96-bb68-c48580ae56b5"), 
                    IdGpResult = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2"), 
                    Lap = 1, 
                    Time = new TimeSpan(1, 1, 1) },
                new Pit { Id = Guid.Parse("c98a567e-e22b-434d-8ab3-3a36976a4030"),
                    IdGpResult = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7"),
                    Lap = 2,
                    Time = new TimeSpan(2, 2, 2) },
                new Pit { Id = Guid.Parse("b5637699-ba17-41ad-be59-11eb4bb3b866"),
                    IdGpResult = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff"),
                    Lap = 3,
                    Time = new TimeSpan(3,31, 3) }
            };
        }

        public Task<Pit> AddAsync(Pit entity)
        {
            entity.Id = Guid.Parse("d23e3da7-c36d-494a-ae48-83b15783dcc1");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Pit entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Pit>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Pit> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Pit entity)
        {
            return Task.FromResult(true);
        }
    }
}
