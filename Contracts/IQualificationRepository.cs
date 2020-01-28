using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IQualificationRepository : IRepositoryBase<Qualification>
    {
        //IEnumerable<Qualification> QualificatinsByParticipant(Guid participantId);
    }
}
