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
    public class TypeFinishRepository : RepositoryBase<TypeFinish>, ITypeFinishRepository
    {
        public TypeFinishRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTypeFinish(TypeFinish typeFinish) =>
            Create(typeFinish);

        public void DeleteTypeFinish(TypeFinish typeFinish) =>
            Delete(typeFinish);

        public async Task<IEnumerable<TypeFinish>> GetAllTypeFinishAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<TypeFinish> GetTypeFinishAsync(Guid typeFinishId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(typeFinishId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
