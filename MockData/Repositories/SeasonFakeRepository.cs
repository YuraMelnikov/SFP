using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class SeasonFakeRepository : IRepositoryBase<Season>, ISeasonRepository
    {
        private readonly List<Season> _list;

        public SeasonFakeRepository()
        {
            _list = new List<Season>
            {
                new Season { Id = Guid.Parse("ea42fba8-69c7-43f5-9bb2-aa81629747c5"), 
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"), 
                    Year = 2000, 
                    IdTypeCalculate = Guid.Parse("ea399aa9-d11f-45db-8a8b-528fe554e396") },
                new Season { Id = Guid.Parse("faffbfdb-7480-48b1-96a8-fd6e21608939"), 
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"), 
                    Year = 2002,  
                    IdTypeCalculate = Guid.Parse("2bb8cdc0-4eb9-46ea-9e37-668dc692edc3")},
                new Season { Id = Guid.Parse("91551759-6a71-4b1e-a908-b8d8684e0e2d"), 
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"), 
                    Year = 2011,  
                    IdTypeCalculate = Guid.Parse("da2b9101-7a02-4b64-a0c7-126ad1ed6845")}
            };
        }

        public Task<IEnumerable<Season>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<Season> AddAsync(Season entity)
        {
            entity.Id = Guid.Parse("bcfdb7e4-b0f6-4b6a-b4ed-2b63014b648c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<Season> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(Season entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(Season entity)
        {
            return Task.FromResult(true);
        }
    }
}
