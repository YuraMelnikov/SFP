using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MockData.Repositories
{
    public class RacerFakeRepository : IRepositoryBase<Racer>, IRacerRepository
    {
        private readonly List<Racer> _list;

        public RacerFakeRepository()
        {
            _list = new List<Racer>
            {
                new Racer{ Id = Guid.Parse("7895c2da-fdb0-457d-b26e-957f25dd4271"),
                    Born = DateTime.Now,
                    BornIn = "bornIn1",
                    Dead = null,
                    DeadIn = "",
                    FirstName = "fn1",
                    IdCountry = Guid.Parse("4c04383f-47e3-4b38-8618-6899ab56b8f7"),
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    SecondName = "sn1",
                    TextData = "td1" },
                new Racer{ Id = Guid.Parse("ff62f9f3-4f23-4331-a073-9ea0c82f79d1"),
                    Born = DateTime.Now,
                    BornIn = "bornIn2",
                    Dead = DateTime.Now,
                    DeadIn = "",
                    FirstName = "fn1",
                    IdCountry = Guid.Parse("49540220-8f9a-49d9-aa96-c4c2916e26bf"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    SecondName = "sn2",
                    TextData = "td2" },
                new Racer{ Id = Guid.Parse("69566e80-71e1-4618-b4ee-8abf931ea00f"),
                    Born = DateTime.Now,
                    BornIn = "bornIn3",
                    Dead = null,
                    DeadIn = "",
                    FirstName = "fn3",
                    IdCountry = Guid.Parse("05185bec-7456-4585-ba5a-d99879ad3ba6"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    SecondName = "sn3",
                    TextData = "td3" }
            };
        }
        public Task<Racer> AddAsync(Racer entity)
        {
            entity.Id = Guid.Parse("9ce154c4-9845-4e44-8eea-b35cfcf3d3cc");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Racer entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Racer>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Racer> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Racer entity)
        {
            return Task.FromResult(true);
        }
    }
}
