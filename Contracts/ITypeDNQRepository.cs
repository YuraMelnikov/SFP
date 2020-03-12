using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITypeDNQRepository
    {
        Task<IEnumerable<TypeDNQ>> GetAllTypeDNQAsync(bool trackChanges);
        Task<TypeDNQ> GetTypeDNQAsync(Guid typeDNQId, bool trackChanges);
        void CreateTypeDNQ(TypeDNQ typeDNQ);
        void DeleteTypeDNQ(TypeDNQ typeDNQ);
    }
}
