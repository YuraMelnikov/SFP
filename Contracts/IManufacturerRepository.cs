using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IManufacturerRepository : IRepositoryBase<Manufacturer>
    {
        //IEnumerable<Manufacturer> ManufacturersByCountry(Guid countryId);
        //IEnumerable<Manufacturer> ManufacturersByImage(Guid imageId);
    }
}
