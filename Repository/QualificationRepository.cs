using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class QualificationRepository : RepositoryBase<Qualification>, IQualificationRepository
    {
        public QualificationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
