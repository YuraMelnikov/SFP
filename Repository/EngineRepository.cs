using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class EngineRepository : RepositoryBase<Engine>, IEngineRepository
    {
        public EngineRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
