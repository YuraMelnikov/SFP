using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IFineRepository : IRepositoryBase<Fine>
    {
        //IEnumerable<Fine> FinesByGPResult(Guid gpResultId);
    }
}
