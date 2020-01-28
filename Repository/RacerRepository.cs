using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class RacerRepository : RepositoryBase<Racer>, IRacerRepository
    {
        public RacerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
