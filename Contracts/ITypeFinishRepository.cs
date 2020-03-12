using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITypeFinishRepository 
    {
        Task<IEnumerable<TypeFinish>> GetAllTypeFinishAsync(bool trackChanges);
        Task<TypeFinish> GetTypeFinishAsync(Guid typeFinishId, bool trackChanges);
        void CreateTypeFinish(TypeFinish typeFinish);
        void DeleteTypeFinish(TypeFinish typeFinish);
    }
}
