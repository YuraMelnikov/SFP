using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TypeFinishRepository : RepositoryBase<TypeFinish>, ITypeFinishRepository
    {
        public TypeFinishRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
