using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MockData.Repositories
{
    public class GPResultFakeRepository : IRepositoryBase<GPResult>, IGPResultRepository
    {
        private readonly List<GPResult> _list;

        public GPResultFakeRepository()
        {
            _list = new List<GPResult>
            {
                new GPResult { Id = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2"),
                    AverageSpeed = 0.1f,
                    IdParticipant = Guid.Parse("75b306b7-7f52-49b3-b7d5-009bd97e78c7"),
                    IdTypeFinish = Guid.Parse("5b11bf69-8980-45eb-b7ea-17fabaa8c905"),
                    Lap = 1,
                    Time = new TimeSpan(12, 30, 45) },
                new GPResult { Id = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7"),
                    AverageSpeed = 0.2f,
                    IdParticipant = Guid.Parse("50cd65bf-f767-47ca-bab2-a69eedc30908"),
                    IdTypeFinish = Guid.Parse("c0d0a251-6155-4cec-ac73-6024c0ac9c8e"),
                    Lap = 2,
                    Time = new TimeSpan(10, 11, 30) },
                new GPResult { Id = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff"),
                    AverageSpeed = 3.3f,
                    IdParticipant = Guid.Parse("dbf46da9-6fe5-4b86-a08a-fd0b40570241"),
                    IdTypeFinish = Guid.Parse("c1fd04a2-834b-4a16-b893-35f08fde6cf1"),
                    Lap = 3,
                    Time = new TimeSpan(8, 5, 6) }
            };
        }

        public Task<GPResult> AddAsync(GPResult entity)
        {
            entity.Id = Guid.Parse("d23e3da7-c36d-494a-ae48-83b15783dcc1");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(GPResult entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<GPResult>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<GPResult> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(GPResult entity)
        {
            return Task.FromResult(true);
        }
    }
}
