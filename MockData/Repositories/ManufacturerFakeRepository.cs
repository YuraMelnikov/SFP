using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using System.Linq;
using Contracts;

namespace MockData.Repositories
{
    public class ManufacturerFakeRepository : IRepositoryBase<Manufacturer>, IManufacturerRepository
    {
        private readonly List<Manufacturer> _list;

        public ManufacturerFakeRepository()
        {
            _list = new List<Manufacturer>
            {
                new Manufacturer { Id = Guid.Parse("6914f662-dbe3-47fb-b755-2e24d13ce853"),
                    IdCountry = Guid.Parse("4c04383f-47e3-4b38-8618-6899ab56b8f7"),
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    Name = "name1"   },
                new Manufacturer { Id = Guid.Parse("eec82f16-82b8-4149-9691-0560f0c3a3d8"),
                    IdCountry = Guid.Parse("49540220-8f9a-49d9-aa96-c4c2916e26bf"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    Name = "name2"   },
                new Manufacturer { Id = Guid.Parse("ad6e38f2-40fb-46fa-a756-42622c0e8227"),
                    IdCountry = Guid.Parse("05185bec-7456-4585-ba5a-d99879ad3ba6"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    Name = "name3"   }
            };
        }

        public Task<Manufacturer> AddAsync(Manufacturer entity)
        {
            entity.Id = Guid.Parse("40feba74-0407-4fe4-a72a-bc5b1e3ad42a");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Manufacturer entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<Manufacturer> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Manufacturer entity)
        {
            return Task.FromResult(true);
        }
    }
}
