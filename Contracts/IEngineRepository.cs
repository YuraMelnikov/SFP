using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IEngineRepository : IRepositoryBase<Engine>
    {
        //IEnumerable<Engine> EnginesByManufacturer(Guid manufacturerId);
        //IEnumerable<Engine> EnginesByImage(Guid imageId);
    }
}
