using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TypeFailRepository : RepositoryBase<TypeFail>, ITypeFailRepository
    {
        public TypeFailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
