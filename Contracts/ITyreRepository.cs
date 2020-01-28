using Entities.Models;
using System;

namespace Contracts
{
    public interface ITyreRepository : IRepositoryBase<Tyre>
    {
        //IEquatable<Tyre> TyresByImage(Guid imageId);
    }
}
