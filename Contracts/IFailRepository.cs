using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFailRepository
    {
        Task<IEnumerable<Fail>> GetAllFailAsync(bool trackChanges);
        Task<Fail> GetFailAsync(Guid failId, bool trackChanges);
        void CreateFail(Fail fail);
        void DeleteFail(Fail fail);
    }
}
