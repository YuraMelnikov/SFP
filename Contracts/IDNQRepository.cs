using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IDNQRepository : IRepositoryBase<DNQ>
    {
        //IEnumerable<DNQ> DNQsByGPResult(Guid gpResultId);
        //IEnumerable<DNQ> DNQsByTypeDNQ(Guid typeDNQId);
    }
}
