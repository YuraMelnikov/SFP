using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IChassiRepository
    {
        Task<IEnumerable<Chassi>> GetAllChassisAsync(bool trackChanges);
        Task<Chassi> GetChassiAsync(Guid chassiId, bool trackChanges);
        void CreateChassi(Chassi chassi);
        void DeleteChassi(Chassi chassi);
    }
}
