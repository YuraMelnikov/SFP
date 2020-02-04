using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MockData.Repositories
{
    public class TrackСonfigurationFakeRepository : IRepositoryBase<TrackСonfiguration>, ITrackConfigurationRepository
    {
        private readonly List<TrackСonfiguration> _list;

        public TrackСonfigurationFakeRepository()
        {
            _list = new List<TrackСonfiguration>
            {
                new TrackСonfiguration { Id = Guid.Parse("29cecc46-6d1e-433d-a26f-065f423e03e6"),
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    IdTrack = Guid.Parse("ccb01626-3417-4a2f-a854-3d472d15e792"),
                    Length = 0.1f,
                    Name = "name1" },
                new TrackСonfiguration { Id = Guid.Parse("ea2b89be-f9e6-4c87-ac7c-89f7d52aa095"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    IdTrack = Guid.Parse("8a715f27-80b5-44ea-b7d7-71175a7e3254"),
                    Length = 0.2f,
                    Name = "name2" },
                new TrackСonfiguration { Id = Guid.Parse("8a0019db-0103-477e-a998-417fcdcfb1c3"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    IdTrack = Guid.Parse("afd6ccb9-05c3-47fc-aa9d-4f555400dce4"),
                    Length = 3.3f,
                    Name = "name3" },
            };
        }

        public Task<TrackСonfiguration> AddAsync(TrackСonfiguration entity)
        {
            entity.Id = Guid.Parse("0957b65e-19c1-4288-80b9-9a03b809366f");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(TrackСonfiguration entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<TrackСonfiguration>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<TrackСonfiguration> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(TrackСonfiguration entity)
        {
            return Task.FromResult(true);
        }
    }
}
