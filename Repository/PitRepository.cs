using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class PitRepository : RepositoryBase<Pit>, IPitRepository
    {
        public PitRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
