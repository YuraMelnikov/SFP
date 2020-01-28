using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class ChassiRepository : RepositoryBase<Chassi>, IChassiRepository
    {
        public ChassiRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
