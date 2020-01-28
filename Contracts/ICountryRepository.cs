using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICountryRepository : IRepositoryBase<Country>
    {
        //IEnumerable<Country> CountryesByImage(Guid imageId);
    }
}
