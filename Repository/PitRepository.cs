using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class PitRepository : RepositoryBase<Pit>, IPitRepository
    {
        public PitRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreatePit(Pit pit) =>
            Create(pit);

        public void DeletePit(Pit pit) =>
            Delete(pit);

        public async Task<IEnumerable<Pit>> GetAllPitAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Pit> GetPitAsync(Guid pitId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(pitId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
