using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class QualificationFakeRepository : IRepositoryBase<Qualification>, IQualificationRepository
    {
        private readonly List<Qualification> _list;

        public QualificationFakeRepository()
        {
            _list = new List<Qualification>
            {
                new Qualification { Id = Guid.Parse("f0bb97cf-0d4f-4ace-96b3-6fbf907fcbb0"), 
                    AverageSpeed = 0.1f, 
                    IdParticipant = Guid.Parse("75b306b7-7f52-49b3-b7d5-009bd97e78c7"), 
                    Position = 1, 
                    Time = new TimeSpan(1, 1, 11) },
                new Qualification { Id = Guid.Parse("aee2a1c0-5029-42bc-8617-44dcaff7ce98"),
                    AverageSpeed = 0.2f,
                    IdParticipant = Guid.Parse("50cd65bf-f767-47ca-bab2-a69eedc30908"),
                    Position = 2,
                    Time = new TimeSpan(0, 0, 11) },
                new Qualification { Id = Guid.Parse("4f5d999d-c5ed-4076-9275-ab76ffd2184d"),
                    AverageSpeed = 0.3f,
                    IdParticipant = Guid.Parse("dbf46da9-6fe5-4b86-a08a-fd0b40570241"),
                    Position = 3,
                    Time = new TimeSpan(0, 1, 11) },
            };
        }

        public Task<Qualification> AddAsync(Qualification entity)
        {
            entity.Id = Guid.Parse("9ce154c4-9845-4e44-8eea-b35cfcf3d3cc");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Qualification entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Qualification>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Qualification> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Qualification entity)
        {
            return Task.FromResult(true);
        }
    }
}
