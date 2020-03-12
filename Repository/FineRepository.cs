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
    public class FineRepository : RepositoryBase<Fine>, IFineRepository
    {
        public FineRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateFine(Fine fine) =>
            Create(fine);

        public void DeleteFine(Fine fine) =>
            Delete(fine);

        public async Task<IEnumerable<Fine>> GetAllFineAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Fine> GetFineAsync(Guid fineId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(fineId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
