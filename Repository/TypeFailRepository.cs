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
    public class TypeFailRepository : RepositoryBase<TypeFail>, ITypeFailRepository
    {
        public TypeFailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTypeFail(TypeFail typeFail) =>
            Create(typeFail);

        public void DeleteTypeFail(TypeFail typeFail) =>
            Delete(typeFail);

        public async Task<IEnumerable<TypeFail>> GetAllTypeFailAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<TypeFail> GetTypeFailAsync(Guid typeFailId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(typeFailId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
