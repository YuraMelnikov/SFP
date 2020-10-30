using Entities;
using Microsoft.EntityFrameworkCore;

namespace ParserApp
{
    public class RepositoryParcer : RepositoryContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=Narodowy3;Server=localhost;Port=5432;Database=Portal;Integrated Security=true;Pooling=true;");
        }
    }
}
