using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ISeasonRepository : IRepositoryBase<Season>
    {
        //IEnumerable<Season> SeasonsByImages(Guid imagesId);
        //IEnumerable<Season> SeasonsByTypeCalculate(Guid typeCalculateId);
    }
}
