using System;
using System.Collections.Generic;
using Contracts;
using System.Threading.Tasks;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class EngineFakeRepository : IRepositoryBase<Engine>, IEngineRepository
    {
        private readonly List<Engine> _list;

        public EngineFakeRepository()
        {
            _list = new List<Engine>
            {
                new Engine { Id = Guid.Parse("6a8fb6aa-af56-44aa-9eb3-455a6d3b9aaf"),
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    IdManufacturer = Guid.Parse("6914f662-dbe3-47fb-b755-2e24d13ce853"),
                    Name = "name1" },
                new Engine { Id = Guid.Parse("24350246-4cde-44c4-b749-c10b7e51edbd"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    IdManufacturer = Guid.Parse("eec82f16-82b8-4149-9691-0560f0c3a3d8"),
                    Name = "name2" },
                new Engine { Id = Guid.Parse("bbd1bccf-53bc-401a-a4fb-f1181f7a96ae"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    IdManufacturer = Guid.Parse("ad6e38f2-40fb-46fa-a756-42622c0e8227"),
                    Name = "name3" }
            };
        }

        public Task<Engine> AddAsync(Engine entity)
        {
            entity.Id = Guid.Parse("048270ba-566d-4e01-a506-a206563b27c2");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Engine entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Engine>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Engine> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Engine entity)
        {
            return Task.FromResult(true);
        }
    }
}
