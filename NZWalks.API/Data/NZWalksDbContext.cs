using Microsoft.EntityFrameworkCore;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("c799067b-3855-4749-9f51-b34455ae1a37"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("fbcf1091-851d-4ee9-b642-c1429e91c26a"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("162dfa92-4ab8-4e54-ac14-65aa1660e3cc"),
                    Name = "Hard"
                }
            };
            // Seed data into the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for region
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("814c997d-aacc-4197-93da-4577d2b1e72b"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "image.png"
                },
                new Region
                {
                    Id = Guid.Parse("2a5d02f5-cee9-45c0-8ceb-9c0b2fe894d3"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "image.png"
                },
                new Region
                {
                    Id = Guid.Parse("0c3ba714-3a50-4b93-97b8-c5ece20f5d02"),
                    Name = "SouthLand",
                    Code = "STL",
                    RegionImageUrl = "image.png"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
