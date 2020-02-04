using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class CountryFakeRepository : IRepositoryBase<Country>, ICountryRepository
    {
        private readonly List<Country> _list;

        public CountryFakeRepository()
        {
            _list = new List<Country>
            {
                new Country { 
                    Id = Guid.Parse("4c04383f-47e3-4b38-8618-6899ab56b8f7"), 
                    Name = "name1", 
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1")
                },
                new Country {
                    Id = Guid.Parse("49540220-8f9a-49d9-aa96-c4c2916e26bf"), 
                    Name = "name2", 
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1")
                },
                new Country {
                    Id = Guid.Parse("05185bec-7456-4585-ba5a-d99879ad3ba6"), 
                    Name = "name3", 
                    IdImage = Guid.Parse("EC1C9706-18FE-11E6-8B6F-0050569977A1")
                },
            };
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<Country> AddAsync(Country entity)
        {
            entity.Id = Guid.Parse("b7628eec-8dca-420f-ae25-91c2dd32f408");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<Country> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(Country entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(Country entity)
        {
            return Task.FromResult(true);
        }
    }
}
