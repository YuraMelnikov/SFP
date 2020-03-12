using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGPRepository 
    {
        Task<IEnumerable<GP>> GetAllGPAsync(bool trackChanges);
        Task<GP> GetGPAsync(Guid gpId, bool trackChanges);
        void CreateGP(GP gp);
        void DeleteGP(GP gp);
    }
}
