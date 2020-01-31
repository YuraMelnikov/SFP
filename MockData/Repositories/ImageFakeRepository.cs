using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using System.Linq;

namespace MockData.Repositories
{
    public class ImageFakeRepository : IRepositoryBase<Image>
    {
        private readonly List<Image> _list;

        public ImageFakeRepository()
        {
            _list = new List<Image>
            {
                new Image { Id = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"), Description = "desc1", Link = "/link/1" },
                new Image { Id = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"), Description = "desc2", Link = "/link/2" },
                new Image { Id = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"), Description = "desc3", Link = "/link/3" },
                new Image { Id = Guid.Parse("EC1C9706-18FE-11E6-8B6F-0050569977A1"), Description = "desc4", Link = "/link/4" }
            };
        }

        public Task<IEnumerable<Image>> GetAllAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<Image> AddAsync(Image entity)
        {
            entity.Id = Guid.Parse("81c42878-526c-11e7-80f0-08002771598b");
            _list.Add(entity);
            return entity.AsTask();
        }

        public Task<Image> GetByIdAsync(Guid id)
        {
            return _list.First(d => d.Id == id).AsTask();
        }

        public Task<bool> DeleteAsync(Image entity)
        {
            return _list.Remove(entity).AsTask();
        }

        public Task<bool> UpdateAsync(Image entity)
        {
            return Task.FromResult(true);
        }
    }
}
