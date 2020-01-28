using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IFailRepository : IRepositoryBase<Fail>
    {
        //IEnumerable<Fail> FailsByGPResult(Guid gpResult);
        //IEnumerable<Fail> FailsByTypeFails(Guid typeFailId);
    }
}
