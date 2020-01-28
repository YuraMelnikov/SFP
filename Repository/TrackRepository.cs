using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
    {
        public TrackRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
