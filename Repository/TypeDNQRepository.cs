using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TypeDNQRepository : RepositoryBase<TypeDNQ>, ITypeDNQRepository
    {
        public TypeDNQRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
