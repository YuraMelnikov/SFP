using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TyreRepository : RepositoryBase<Tyre>, ITyreRepository
    {
        public TyreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
