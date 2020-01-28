using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class GPRepository : RepositoryBase<GP>, IGPRepository
    {
        public GPRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
