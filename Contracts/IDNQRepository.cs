using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDNQRepository
    {
        Task<IEnumerable<DNQ>> GetAllDNQAsync(bool trackChanges);
        Task<DNQ> GetDNQAsync(Guid dnqId, bool trackChanges);
        void CreateDNQ(DNQ dnq);
        void DeleteDNQ(DNQ dnq);
    }
}
