using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Chassi> Chassis { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DescriptionGPResult> DescriptionGPResults { get; set; }
        public DbSet<DNQ> DNQs { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Fail> Fails { get; set; }
        public DbSet<FastLap> FastLaps { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<GP> GPs { get; set; }
        public DbSet<GPResult> GPResults { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<LeaderLap> LeaderLaps { get; set; }
        public DbSet<Livery> Liveries { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Pit> Pits { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Racer> Racers { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamName> TeamNames { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackСonfiguration> TrackСonfigurations { get; set; }
        public DbSet<TypeCalculate> TypeCalculates { get; set; }
        public DbSet<TypeDNQ> TypeDNQs { get; set; }
        public DbSet<TypeFail> TypeFails { get; set; }
        public DbSet<TypeFinish> TypeFinishes { get; set; }
        public DbSet<Tyre> Tyres { get; set; }
    }
}
