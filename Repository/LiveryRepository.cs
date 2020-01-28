using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class LiveryRepository : RepositoryBase<Livery>, ILiveryRepository
    {
        public LiveryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
