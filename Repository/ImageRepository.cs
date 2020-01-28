using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
