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
    public class ChassiRepository : RepositoryBase<Chassi>, IChassiRepository
    {
        public ChassiRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateChassi(Chassi chassi) =>
            Create(chassi);

        public void DeleteChassi(Chassi chassi) =>
            Delete(chassi);

        public async Task<IEnumerable<Chassi>> GetAllChassisAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Chassi> GetChassiAsync(Guid chassiId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(chassiId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
