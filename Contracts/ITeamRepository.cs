using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ITeamRepository : IRepositoryBase<Team>
    {
        //IEnumerable<Team> TeamsByCountry(Guid countryId);
        //IEnumerable<Team> TeamsByImage(Guid imageId);
    }
}
