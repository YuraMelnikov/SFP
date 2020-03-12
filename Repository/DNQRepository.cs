using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DNQRepository : RepositoryBase<DNQ>, IDNQRepository
    {
        public DNQRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateDNQ(DNQ dnq) =>
            Create(dnq);

        public void DeleteDNQ(DNQ dnq) =>
            Delete(dnq);

        public async Task<IEnumerable<DNQ>> GetAllDNQAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<DNQ> GetDNQAsync(Guid dnqId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(dnqId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
