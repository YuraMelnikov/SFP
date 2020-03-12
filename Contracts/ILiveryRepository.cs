using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILiveryRepository 
    {
        Task<IEnumerable<Livery>> GetAllLiveryAsync(bool trackChanges);
        Task<Livery> GetLiveryAsync(Guid liveryId, bool trackChanges);
        void CreateLivery(Livery livery);
        void DeleteLivery(Livery livery);
    }
}
