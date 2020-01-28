using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
