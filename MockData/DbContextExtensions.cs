using System;
using Entities.Models;
using Entities;

namespace MockData
{
    public static class DbContextExtensions
    {
        public static void Seed(this RepositoryContext context)
        {
            context.Images.Add(new Image { Id = Guid.Parse("75078E17-0D1B-11E6-8B6F-0050569977A1"), Description = "desc1", Link = "/link/1" });
            context.Images.Add(new Image { Id = Guid.Parse("CDF12109-10D3-11E6-8B6F-0050569977A1"), Description = "desc2", Link = "/link/2" });
            context.Images.Add(new Image { Id = Guid.Parse("ED3103B6-15F5-11E6-8B6F-0050569977A1"), Description = "desc3", Link = "/link/3" });
            context.Images.Add(new Image { Id = Guid.Parse("EC1C9706-18FE-11E6-8B6F-0050569977A1"), Description = "desc4", Link = "/link/4" });
            context.SaveChanges();
        }

    }
}
