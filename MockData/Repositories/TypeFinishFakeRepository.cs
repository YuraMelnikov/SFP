using System;
using System.Collections.Generic;
using Contracts;
using System.Threading.Tasks;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class TypeFinishFakeRepository : IRepositoryBase<TypeFinish>, ITypeFinishRepository
    {
        private readonly List<TypeFinish> _list;

        public TypeFinishFakeRepository()
        {
            _list = new List<TypeFinish>
            {
                new TypeFinish { Id = Guid.Parse("5b11bf69-8980-45eb-b7ea-17fabaa8c905"),
                    Name = "name1",
                    ShortName = "sName1" },
                new TypeFinish { Id = Guid.Parse("c0d0a251-6155-4cec-ac73-6024c0ac9c8e"),
                    Name = "name1",
                    ShortName = "sName1" },
                new TypeFinish { Id = Guid.Parse("c1fd04a2-834b-4a16-b893-35f08fde6cf1"),
                    Name = "name1",
                    ShortName = "sName1" },
            };
        }

        public Task<TypeFinish> AddAsync(TypeFinish entity)
        {
            entity.Id = Guid.Parse("e17b5d33-0e75-4876-8c3f-4d20ab114d63");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(TypeFinish entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<TypeFinish>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<TypeFinish> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(TypeFinish entity)
        {
            return Task.FromResult(true);
        }
    }
}
