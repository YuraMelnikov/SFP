using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ITeamNameRepository : IRepositoryBase<TeamName>
    {
        //IEnumerable<Team> TeamsBySeason(Guid seasonId);
    }
}
