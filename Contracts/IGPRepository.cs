using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IGPRepository : IRepositoryBase<GP>
    {
        //IEnumerable<GP> GPsByImage(Guid imageId);
    }
}
