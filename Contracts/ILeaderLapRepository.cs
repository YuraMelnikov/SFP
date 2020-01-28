using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ILeaderLapRepository : IRepositoryBase<LeaderLap>
    {
        //IEnumerable<LeaderLap> LeaderLapsByGPResult(Guid gpResultId);
    }
}
