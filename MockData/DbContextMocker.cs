using Microsoft.EntityFrameworkCore;
using Entities;

namespace MockData
{
    public static class DbContextMocker
    {
        public static RepositoryContext GetRepositoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            var dbContext = new RepositoryContext(options);
            dbContext.Seed();
            return dbContext;
        }
    }
}