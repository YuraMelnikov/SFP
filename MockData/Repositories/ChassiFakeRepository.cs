using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class ChassiFakeRepository : IRepositoryBase<Chassi>, IChassiRepository 
    {
        private readonly List<Chassi> _list;

        public ChassiFakeRepository()
        {
            _list = new List<Chassi>
            {
                new Chassi { Id = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"), 
                    IdImage = Guid.Parse("a2df9da7-8cb2-4739-a80f-4487cbb84a88"), 
                    IdLivery = Guid.Parse("70cdb133-2640-4e5c-b5c3-938c41b94968"), 
                    IdManufacturer = Guid.Parse("0561f7aa-8b58-484e-badf-e311d4874d99"),
                    Name = "name1" },
                new Chassi { Id = Guid.Parse("73cd36a4-65b4-4207-9d85-dbffbe27ce6f"),
                    IdImage = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"),
                    IdLivery = Guid.Parse("7f870b9f-dc61-4b5e-9f52-3124585b75d0"),
                    IdManufacturer = Guid.Parse("9a2fb858-b38d-4a02-bd1f-d7e7a40aca8e"),
                    Name = "name2" },
                new Chassi { Id = Guid.Parse("8fd54d83-de9e-49a5-99bb-c7192a710c3d"),
                    IdImage = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"),
                    IdLivery = Guid.Parse("24e171ab-5f66-49a3-aa5f-c50c934b5a37"),
                    IdManufacturer = Guid.Parse("2b0c8212-2d7d-4f1c-b371-dde804f0be2c"),
                    Name = "name3" }
            };
        }

        public Task<IEnumerable<Chassi>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<Chassi> AddAsync(Chassi entity)
        {
            entity.Id = Guid.Parse("bcfdb7e4-b0f6-4b6a-b4ed-2b63014b648c");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<Chassi> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(Chassi entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(Chassi entity)
        {
            return Task.FromResult(true);
        }
    }
}
