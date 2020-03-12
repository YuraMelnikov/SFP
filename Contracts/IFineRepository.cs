using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFineRepository 
    {
        Task<IEnumerable<Fine>> GetAllFineAsync(bool trackChanges);
        Task<Fine> GetFineAsync(Guid fineId, bool trackChanges);
        void CreateFine(Fine fine);
        void DeleteFine(Fine fine);
    }
}
