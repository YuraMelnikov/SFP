using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDescriptionGPResultRepository
    {
        Task<IEnumerable<DescriptionGPResult>> GetAllDescriptionGPResultAsync(bool trackChanges);
        Task<DescriptionGPResult> GetDescriptionGPResultAsync(Guid descriptionGPResultId, bool trackChanges);
        void CreateDescriptionGPResult(DescriptionGPResult descriptionGPResult);
        void DeleteDescriptionGPResult(DescriptionGPResult descriptionGPResult);
    }
}
