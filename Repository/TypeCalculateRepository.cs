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
    public class TypeCalculateRepository : RepositoryBase<TypeCalculate>, ITypeCalculateRepository
    {
        public TypeCalculateRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTypeCalculate(TypeCalculate typeCalculate) =>
            Create(typeCalculate);

        public void DeleteTypeCalculate(TypeCalculate typeCalculate) =>
            Delete(typeCalculate);

        public async Task<IEnumerable<TypeCalculate>> GetAllTypeCalculateAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<TypeCalculate> GetTypeCalculateAsync(Guid typeCalculateId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(typeCalculateId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
