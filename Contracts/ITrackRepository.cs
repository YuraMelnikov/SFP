using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ITrackRepository : IRepositoryBase<Track>
    {
        //IEnumerable<Track> TracksByCountry(Guid countryId);
        //IEnumerable<Track> TracksByImage(Guid imageId);
    }
}
