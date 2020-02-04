using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class LiveryFakeRepository : IRepositoryBase<Livery>, ILiveryRepository
    {
        private readonly List<Livery> _list;

        public LiveryFakeRepository()
        {
            _list = new List<Livery>
            {
                new Livery { Id = Guid.Parse("70cdb133-2640-4e5c-b5c3-938c41b94968"),
                    Link = "//link1/1" },
                new Livery { Id = Guid.Parse("7f870b9f-dc61-4b5e-9f52-3124585b75d0"),
                    Link = "//link2/2" },
                new Livery { Id = Guid.Parse("24e171ab-5f66-49a3-aa5f-c50c934b5a37"),
                    Link = "//link3" }
            };
        }

        public Task<Livery> AddAsync(Livery entity)
        {
            entity.Id = Guid.Parse("8c9efaf8-5e39-43e4-8ebc-ce28a10b24f9");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Livery entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Livery>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<Livery> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Livery entity)
        {
            return Task.FromResult(true);
        }
    }
}
