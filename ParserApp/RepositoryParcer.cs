using Entities;
using Microsoft.EntityFrameworkCore;

namespace ParserApp
{
    public class RepositoryParcer : RepositoryContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=Narodowy3_;Server=localhost;Port=5432;Database=SFDB;Integrated Security=true;Pooling=true;");
        }
    }
}
