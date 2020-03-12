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
    public class LiveryRepository : RepositoryBase<Livery>, ILiveryRepository
    {
        public LiveryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateLivery(Livery livery) =>
            Create(livery);

        public void DeleteLivery(Livery livery) =>
            Delete(livery);

        public async Task<IEnumerable<Livery>> GetAllLiveryAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Livery> GetLiveryAsync(Guid liveryId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(liveryId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
