using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IChassiRepository : IRepositoryBase<Chassi>
    {
        //IEnumerable<Chassi> ChassisByManufacturer(Guid manufacturerId);
        //IEnumerable<Chassi> ChassisByImage(Guid imageId);
        //IEnumerable<Chassi> ChassisByLivery(Guid liveryId);
    }
}
