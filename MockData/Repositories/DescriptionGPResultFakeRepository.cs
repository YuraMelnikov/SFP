using System;
using System.Collections.Generic;
using Contracts;
using System.Threading.Tasks;
using System.Linq;
using Entities.Models;

namespace MockData.Repositories
{
    public class DescriptionGPResultFakeRepository : IRepositoryBase<DescriptionGPResult>, IDescriptionGPResultRepository
    {
        private readonly List<DescriptionGPResult> _list;

        public DescriptionGPResultFakeRepository()
        {
            _list = new List<DescriptionGPResult>
            {
                new DescriptionGPResult { Id = Guid.Parse("9fe2cff1-a1d0-4162-b026-907c066f96b4"), 
                    Description = "desc1",
                    IdGpResult = Guid.Parse("14c00858-ed72-48f4-8cca-e2231e8d62c2") },
                new DescriptionGPResult { Id = Guid.Parse("4fb45e69-7214-46a3-85df-e49eaf91d6c4"),
                    Description = "desc2",
                    IdGpResult = Guid.Parse("cb601c20-cf70-413a-a2f4-cb1a94f74bb7") },
                new DescriptionGPResult { Id = Guid.Parse("45b5b1b2-483a-4f7c-b906-bc82305682de"),
                    Description = "desc3",
                    IdGpResult = Guid.Parse("056c0df6-ff00-4d88-a079-f411646c9eff") }
            };
        }

        public Task<DescriptionGPResult> AddAsync(DescriptionGPResult entity)
        {
            entity.Id = Guid.Parse("b2db2eea-a219-44c6-982e-1d4411b84e12");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(DescriptionGPResult entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<DescriptionGPResult>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<DescriptionGPResult> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(DescriptionGPResult entity)
        {
            return Task.FromResult(true);
        }
    }
}
