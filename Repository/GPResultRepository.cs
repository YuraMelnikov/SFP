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
    public class GPResultRepository : RepositoryBase<GPResult>, IGPResultRepository
    {
        public GPResultRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateGPResult(GPResult gpResult) =>
            Create(gpResult);

        public void DeleteGPResult(GPResult gpResult) =>
            Delete(gpResult);

        public async Task<IEnumerable<GPResult>> GetAllGPResultAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<GPResult> GetGPResultAsync(Guid gpResultId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(gpResultId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
