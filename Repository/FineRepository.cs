using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FineRepository : RepositoryBase<Fine>, IFineRepository
    {
        public FineRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
