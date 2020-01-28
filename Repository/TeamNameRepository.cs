using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TeamNameRepository : RepositoryBase<TeamName>, ITeamNameRepository
    {
        public TeamNameRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
