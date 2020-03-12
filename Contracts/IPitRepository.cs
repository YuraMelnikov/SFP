using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPitRepository 
    {
        Task<IEnumerable<Pit>> GetAllPitAsync(bool trackChanges);
        Task<Pit> GetPitAsync(Guid pitId, bool trackChanges);
        void CreatePit(Pit pit);
        void DeletePit(Pit pit);
    }
}
