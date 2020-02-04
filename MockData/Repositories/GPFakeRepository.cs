using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class GPFakeRepository : IRepositoryBase<GP>, IGPRepository
    {
        private readonly List<GP> _list;

        public GPFakeRepository()
        {
            _list = new List<GP>
            {
                new GP { Id = Guid.Parse("67f8c361-7883-4c01-bdb2-bc456258fde1"),
                    Date = DateTime.Now,
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    IdTrackСonfiguration = Guid.Parse("29cecc46-6d1e-433d-a26f-065f423e03e6"),
                    Name = "name1",
                    Num = 1,
                    NumInSeason = 1,
                    PercentDistance = 80,
                    Weather = "weat1" },
                new GP { Id = Guid.Parse("0b00264f-867b-49f5-ace4-4f2fd0d7b58d"),
                    Date = DateTime.Now,
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    IdTrackСonfiguration = Guid.Parse("ea2b89be-f9e6-4c87-ac7c-89f7d52aa095"),
                    Name = "name2",
                    Num = 2,
                    NumInSeason = 2,
                    PercentDistance = 90,
                    Weather = "weat2" },
                new GP { Id = Guid.Parse("185fcd63-afae-4e5a-abfc-ac808013f393"),
                    Date = DateTime.Now,
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    IdTrackСonfiguration = Guid.Parse("8a0019db-0103-477e-a998-417fcdcfb1c3"),
                    Name = "name3",
                    Num = 3,
                    NumInSeason = 3,
                    PercentDistance = 100,
                    Weather = "weat3" }
            };
        }

        public Task<GP> AddAsync(GP entity)
        {
            entity.Id = Guid.Parse("9ce154c4-9845-4e44-8eea-b35cfcf3d3cc");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(GP entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<GP>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<GP> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(GP entity)
        {
            return Task.FromResult(true);
        }
    }
}
