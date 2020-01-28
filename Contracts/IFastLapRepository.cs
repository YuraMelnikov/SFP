using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IFastLapRepository : IRepositoryBase<FastLap>
    {
        //IEnumerable<FastLap> FastLapsByGPResult(Guid gpResultId);
    }
}
