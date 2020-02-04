using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MockData.Repositories
{
    public class LeaderLapFakeRepository : IRepositoryBase<LeaderLap>, ILeaderLapRepository
    {
        private readonly List<LeaderLap> _list;

        public LeaderLapFakeRepository()
        {
            _list = new List<LeaderLap>
            {
                new LeaderLap { Id = Guid.Parse("5460c10e-e829-4778-97be-b19d194f01f1"), 
                    IdGpResult = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2"), 
                    First = 1, 
                    Last = 2 },
                new LeaderLap { Id = Guid.Parse("844f9067-bc4c-4e83-a020-b665825dbcc8"),
                    IdGpResult = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7"),
                    First = 3,
                    Last = 4 },
                new LeaderLap { Id = Guid.Parse("94495190-4bbb-4b94-925a-138f22e73d42"),
                    IdGpResult = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff"),
                    First = 5,
                    Last = 6 }
            };
        }

        public Task<LeaderLap> AddAsync(LeaderLap entity)
        {
            entity.Id = Guid.Parse("d23e3da7-c36d-494a-ae48-83b15783dcc1");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(LeaderLap entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<LeaderLap>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<LeaderLap> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(LeaderLap entity)
        {
            return Task.FromResult(true);
        }
    }
}
