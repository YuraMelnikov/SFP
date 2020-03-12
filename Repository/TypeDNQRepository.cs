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
    public class TypeDNQRepository : RepositoryBase<TypeDNQ>, ITypeDNQRepository
    {
        public TypeDNQRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTypeDNQ(TypeDNQ typeDNQ) =>
            Create(typeDNQ);

        public void DeleteTypeDNQ(TypeDNQ typeDNQ) =>
            Delete(typeDNQ);

        public async Task<IEnumerable<TypeDNQ>> GetAllTypeDNQAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<TypeDNQ> GetTypeDNQAsync(Guid typeDNQId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(typeDNQId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
