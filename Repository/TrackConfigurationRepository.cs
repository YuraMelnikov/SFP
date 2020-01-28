using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TrackConfigurationRepository : RepositoryBase<TrackСonfiguration>, ITrackConfigurationRepository
    {
        public TrackConfigurationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
