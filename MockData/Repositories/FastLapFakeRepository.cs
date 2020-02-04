using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class FastLapFakeRepository : IRepositoryBase<FastLap>, IFastLapRepository
    {
        private readonly List<FastLap> _list;

        public FastLapFakeRepository()
        {
            _list = new List<FastLap>
            {
                new FastLap { Id = Guid.Parse("b22bffa2-c587-4e89-937d-a7a93e7204a8"), 
                    IdGpResult = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2"), 
                    AverageSpeed = 0.1f, Lap = 10, 
                    Time = new TimeSpan(5, 8, 22)},
                new FastLap { Id = Guid.Parse("5d38012d-a801-4de6-ba2b-87d687e3ab5c"),
                    IdGpResult = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7"),
                    AverageSpeed = 0.2f, Lap = 20,
                    Time = new TimeSpan(23, 2, 12)},
                new FastLap { Id = Guid.Parse("c6195bf3-52e6-404c-aa71-1041c7213686"),
                    IdGpResult = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff"),
                    AverageSpeed = 0.3f, Lap = 13,
                    Time = new TimeSpan(11, 22, 33)}
            };
        }

        public Task<FastLap> AddAsync(FastLap entity)
        {
            entity.Id = Guid.Parse("9ce154c4-9845-4e44-8eea-b35cfcf3d3cc");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(FastLap entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<FastLap>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<FastLap> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(FastLap entity)
        {
            return Task.FromResult(true);
        }
    }
}
