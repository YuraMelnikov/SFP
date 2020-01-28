using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class LeaderLapRepository : RepositoryBase<LeaderLap>, ILeaderLapRepository
    {
        public LeaderLapRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
