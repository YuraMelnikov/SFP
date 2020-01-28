using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IGPResultRepository : IRepositoryBase<GPResult>
    {
        //IEnumerable<GPResult> GPResultsByParticipant(Guid participantId);
        //IEnumerable<GPResult> GPResultsByTypeFinish(Guid typeFinishId);
    }
}
