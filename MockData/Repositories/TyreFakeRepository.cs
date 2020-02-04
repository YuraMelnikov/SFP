using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MockData.Repositories
{
    public class TyreFakeRepository : IRepositoryBase<Tyre>, ITyreRepository
    {
        private readonly List<Tyre> _list;

        public TyreFakeRepository()
        {
            _list = new List<Tyre>
            {
                new Tyre { Id = Guid.Parse("af6a937c-690e-4346-816d-2569a079c1cb"), 
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"), 
                    IdManufacturer = Guid.Parse("6914f662-dbe3-47fb-b755-2e24d13ce853"), 
                    Name = "name1" },
                new Tyre { Id = Guid.Parse("3f4e7ded-3044-48b0-b4a7-5ddb399c29ef"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    IdManufacturer = Guid.Parse("eec82f16-82b8-4149-9691-0560f0c3a3d8"),
                    Name = "name2" },
                new Tyre { Id = Guid.Parse("21444265-a328-4f13-bf28-a37c60f8d3e2"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    IdManufacturer = Guid.Parse("ad6e38f2-40fb-46fa-a756-42622c0e8227"),
                    Name = "name3" }
            };
        }

        public Task<Tyre> AddAsync(Tyre entity)
        {
            entity.Id = Guid.Parse("185fff7a-e7a2-412f-838c-0d565fa5664c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Tyre entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Tyre>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Tyre> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Tyre entity)
        {
            return Task.FromResult(true);
        }
    }
}
