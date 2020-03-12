using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITypeCalculateRepository
    {
        Task<IEnumerable<TypeCalculate>> GetAllTypeCalculateAsync(bool trackChanges);
        Task<TypeCalculate> GetTypeCalculateAsync(Guid typeCalculateId, bool trackChanges);
        void CreateTypeCalculate(TypeCalculate typeCalculate);
        void DeleteTypeCalculate(TypeCalculate typeCalculate);
    }
}
