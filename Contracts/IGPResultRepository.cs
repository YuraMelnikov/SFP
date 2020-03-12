using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGPResultRepository 
    {
        Task<IEnumerable<GPResult>> GetAllGPResultAsync(bool trackChanges);
        Task<GPResult> GetGPResultAsync(Guid gPResultId, bool trackChanges);
        void CreateGPResult(GPResult gPResult);
        void DeleteGPResult(GPResult gPResult);
    }
}
