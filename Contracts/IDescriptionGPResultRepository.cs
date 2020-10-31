using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDescriptionGPResultRepository
    {
        Task<IEnumerable<GrandPrixResultNote>> GetAllDescriptionGPResultAsync(bool trackChanges);
        Task<GrandPrixResultNote> GetDescriptionGPResultAsync(Guid descriptionGPResultId, bool trackChanges);
        void CreateDescriptionGPResult(GrandPrixResultNote descriptionGPResult);
        void DeleteDescriptionGPResult(GrandPrixResultNote descriptionGPResult);
    }
}
