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
    public class DescriptionGPResultRepository : RepositoryBase<DescriptionGPResult>, IDescriptionGPResultRepository
    {
        public DescriptionGPResultRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreateDescriptionGPResult(DescriptionGPResult descriptionGPResult) =>
            Create(descriptionGPResult);

        public void DeleteDescriptionGPResult(DescriptionGPResult descriptionGPResult) =>
            Delete(descriptionGPResult);

        public async Task<IEnumerable<DescriptionGPResult>> GetAllDescriptionGPResultAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<DescriptionGPResult> GetDescriptionGPResultAsync(Guid descriptionGPResultId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(descriptionGPResultId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
