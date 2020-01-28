using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class GPResultRepository : RepositoryBase<GPResult>, IGPResultRepository
    {
        public GPResultRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
