using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TypeCalculateRepository : RepositoryBase<TypeCalculate>, ITypeCalculateRepository
    {
        public TypeCalculateRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
