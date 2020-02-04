using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MockData.Repositories
{
    public class TrackFakeRepository : IRepositoryBase<Track>, ITrackRepository
    {
        private readonly List<Track> _list;

        public TrackFakeRepository()
        {
            _list = new List<Track>
            {
                new Track { Id = Guid.Parse("ccb01626-3417-4a2f-a854-3d472d15e792"), 
                    IdCountry = Guid.Parse("4c04383f-47e3-4b38-8618-6899ab56b8f7"),
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    Name = "name1"
                },
                new Track { Id = Guid.Parse("8a715f27-80b5-44ea-b7d7-71175a7e3254"),
                    IdCountry = Guid.Parse("49540220-8f9a-49d9-aa96-c4c2916e26bf"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    Name = "name2"
                },
                new Track { Id = Guid.Parse("afd6ccb9-05c3-47fc-aa9d-4f555400dce4"),
                    IdCountry = Guid.Parse("05185bec-7456-4585-ba5a-d99879ad3ba6"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    Name = "name3"
                }
            };
        }

        public Task<Track> AddAsync(Track entity)
        {
            entity.Id = Guid.Parse("41c97e70-d3f7-422f-bdec-bc861055a824");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Track entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Track>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Track> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Track entity)
        {
            return Task.FromResult(true);
        }
    }
}
