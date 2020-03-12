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
    public class FailRepository : RepositoryBase<Fail>, IFailRepository
    {
        public FailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateFail(Fail fail) =>
            Create(fail);

        public void DeleteFail(Fail fail) =>
            Delete(fail);

        public async Task<IEnumerable<Fail>> GetAllFailAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Fail> GetFailAsync(Guid failId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(failId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
