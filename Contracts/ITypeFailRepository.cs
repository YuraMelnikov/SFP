using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITypeFailRepository
    {
        Task<IEnumerable<TypeFail>> GetAllTypeFailAsync(bool trackChanges);
        Task<TypeFail> GetTypeFailAsync(Guid typeFailId, bool trackChanges);
        void CreateTypeFail(TypeFail typeFail);
        void DeleteTypeFail(TypeFail typeFail);
    }
}
