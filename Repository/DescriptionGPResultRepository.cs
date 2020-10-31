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
    public class DescriptionGPResultRepository : RepositoryBase<GrandPrixResultNote>, IDescriptionGPResultRepository
    {
        public DescriptionGPResultRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreateDescriptionGPResult(GrandPrixResultNote descriptionGPResult) =>
            Create(descriptionGPResult);

        public void DeleteDescriptionGPResult(GrandPrixResultNote descriptionGPResult) =>
            Delete(descriptionGPResult);

        public async Task<IEnumerable<GrandPrixResultNote>> GetAllDescriptionGPResultAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<GrandPrixResultNote> GetDescriptionGPResultAsync(Guid descriptionGPResultId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(descriptionGPResultId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
