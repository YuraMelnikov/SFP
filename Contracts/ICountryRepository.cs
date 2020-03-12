﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync(bool trackChanges);
        Task<Country> GetCountryAsync(Guid countryId, bool trackChanges);
        void CreateCountry(Country country);
        void DeleteCountry(Country country);
    }
}
