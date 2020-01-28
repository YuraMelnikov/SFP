using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FailRepository : RepositoryBase<Fail>, IFailRepository
    {
        public FailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
