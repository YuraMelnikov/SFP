using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IRacerRepository : IRepositoryBase<Racer>
    {
        //IEnumerable<Racer> RacersByCountry(Guid countryId);
        //IEnumerable<Racer> RacersByImage(Guid imageId);
    }
}
