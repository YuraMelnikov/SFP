using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IPitRepository : IRepositoryBase<Pit>
    {
        //IEnumerable<Pit> PitsByGPResult(Guid gPResultId);
    }
}
