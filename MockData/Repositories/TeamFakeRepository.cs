using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MockData.Repositories
{
    public class TeamFakeRepository : IRepositoryBase<Team>, ITeamRepository
    {
        private readonly List<Team> _list;

        public TeamFakeRepository()
        {
            _list = new List<Team>
            {
                new Team { Id = Guid.Parse("ceba9586-3ccd-4bfe-803e-fa8fddd8faed"),
                    IdCountry = Guid.Parse("4c04383f-47e3-4b38-8618-6899ab56b8f7"),
                    IdImage = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    ShortName = "sn1"},
                new Team { Id = Guid.Parse("9c4d10b8-d36c-4e56-91eb-3cc565186da7"),
                    IdCountry = Guid.Parse("49540220-8f9a-49d9-aa96-c4c2916e26bf"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    ShortName = "sn1"},
                new Team { Id = Guid.Parse("d60261bc-a676-4c73-b66c-9a537df561b6"),
                    IdCountry = Guid.Parse("05185bec-7456-4585-ba5a-d99879ad3ba6"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    ShortName = "sn1"},
            };
        }

        public Task<Team> AddAsync(Team entity)
        {
            entity.Id = Guid.Parse("99dd9185-1e90-442b-8175-e5b6b3e623e0");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Team entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Team>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Team> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Team entity)
        {
            return Task.FromResult(true);
        }
    }
}
