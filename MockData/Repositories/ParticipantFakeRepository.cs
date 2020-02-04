using System;
using System.Collections.Generic;
using Contracts;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MockData.Repositories
{
    public class ParticipantFakeRepository : IRepositoryBase<Participant>, IParticipantRepository
    {
        private readonly List<Participant> _list;

        public ParticipantFakeRepository()
        {
            _list = new List<Participant>
            {
                new Participant { Id = Guid.Parse("75b306b7-7f52-49b3-b7d5-009bd97e78c7"),
                    IdChassi = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"),
                    IdEngine = Guid.Parse("6a8fb6aa-af56-44aa-9eb3-455a6d3b9aaf"),
                    IdGp = Guid.Parse("67f8c361-7883-4c01-bdb2-bc456258fde1"),
                    IdRacer = Guid.Parse("7895c2da-fdb0-457d-b26e-957f25dd4271"),
                    IdTeam = Guid.Parse("ceba9586-3ccd-4bfe-803e-fa8fddd8faed"),
                    IdTyre = Guid.Parse("af6a937c-690e-4346-816d-2569a079c1cb"),
                    Num = "1" },
                new Participant { Id = Guid.Parse("50cd65bf-f767-47ca-bab2-a69eedc30908"),
                    IdChassi = Guid.Parse("73cd36a4-65b4-4207-9d85-dbffbe27ce6f"),
                    IdEngine = Guid.Parse("24350246-4cde-44c4-b749-c10b7e51edbd"),
                    IdGp = Guid.Parse("0b00264f-867b-49f5-ace4-4f2fd0d7b58d"),
                    IdRacer = Guid.Parse("ff62f9f3-4f23-4331-a073-9ea0c82f79d1"),
                    IdTeam = Guid.Parse("9c4d10b8-d36c-4e56-91eb-3cc565186da7"),
                    IdTyre = Guid.Parse("3f4e7ded-3044-48b0-b4a7-5ddb399c29ef"),
                    Num = "2" },
                new Participant { Id = Guid.Parse("dbf46da9-6fe5-4b86-a08a-fd0b40570241"),
                    IdChassi = Guid.Parse("8fd54d83-de9e-49a5-99bb-c7192a710c3d"),
                    IdEngine = Guid.Parse("bbd1bccf-53bc-401a-a4fb-f1181f7a96ae"),
                    IdGp = Guid.Parse("185fcd63-afae-4e5a-abfc-ac808013f393"),
                    IdRacer = Guid.Parse("69566e80-71e1-4618-b4ee-8abf931ea00f"),
                    IdTeam = Guid.Parse("d60261bc-a676-4c73-b66c-9a537df561b6"),
                    IdTyre = Guid.Parse("21444265-a328-4f13-bf28-a37c60f8d3e2"),
                    Num = "3" },
            };
        }

        public Task<Participant> AddAsync(Participant entity)
        {
            entity.Id = Guid.Parse("db2c6b2f-3abd-4528-940c-ed62b3115444");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<bool> DeleteAsync(Participant entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<IEnumerable<Participant>> GetAllAsync()
        {
            return _list.AsEnumerable().AsTask();
        }

        public Task<Participant> GetByIdAsync(Guid id)
        {
            return _list.First(a => a.Id == id).AsTask();
        }

        public Task<bool> UpdateAsync(Participant entity)
        {
            return Task.FromResult(true);
        }
    }
}
