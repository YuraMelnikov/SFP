using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DescriptionGPResultRepository : RepositoryBase<DescriptionGPResult>, IDescriptionGPResultRepository
    {
        public DescriptionGPResultRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
    }
}
