using Contracts;
using Entities;
using Entities.Models;

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
