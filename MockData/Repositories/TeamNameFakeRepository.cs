using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MockData.Repositories
{
    public class TeamNameFakeRepository : IRepositoryBase<TeamName>, ITeamNameRepository
    {
        private readonly List<TeamName> _list;

        public TeamNameFakeRepository()
        {
            _list = new List<TeamName>
            {
                new TeamName { Id = Guid.Parse("c08afb6b-9a62-480a-888d-4b64b1edb7a1"), 
                    IdSeasonFinish = Guid.Parse("ea42fba8-69c7-43f5-9bb2-aa81629747c5"), 
                    IdSeasonStart = Guid.Parse("ea399aa9-d11f-45db-8a8b-528fe554e396"), 
                    LongName = "ln1" },
                new TeamName { Id = Guid.Parse("de8da549-87f8-41ea-80a0-2e8a0c9ee1c2"),
                    IdSeasonFinish = Guid.Parse("ea42fba8-69c7-43f5-9bb2-aa81629747c5"),
                    IdSeasonStart = Guid.Parse("91551759-6a71-4b1e-a908-b8d8684e0e2d"),
                    LongName = "ln2" },
                new TeamName { Id = Guid.Parse("c879eb22-ea80-47bc-b1ab-d8737bc17e97"),
                    IdSeasonFinish = Guid.Parse("ea399aa9-d11f-45db-8a8b-528fe554e396"),
                    IdSeasonStart = Guid.Parse("91551759-6a71-4b1e-a908-b8d8684e0e2d"),
                    LongName = "ln3" },
            };
        }

        public Task<TeamName> AddAsync(TeamName entity)
        {
            entity.Id = Guid.Parse("99dd9185-1e90-442b-8175-e5b6b3e623e0");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(TeamName entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<TeamName>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<TeamName> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(TeamName entity)
        {
            return Task.FromResult(true);
        }
    }
}
