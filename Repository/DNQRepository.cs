using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class DNQRepository : RepositoryBase<DNQ>, IDNQRepository
    {
        public DNQRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
