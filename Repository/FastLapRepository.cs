using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FastLapRepository : RepositoryBase<FastLap>, IFastLapRepository
    {
        public FastLapRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
