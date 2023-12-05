using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions):base(dbContextOptions)
        {
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("9c8d4d3c-886c-4047-a246-f83679dad41d"),
                    Name="Easy"
                },
                 new Difficulty()
                {
                    Id=Guid.Parse("ffad5e27-7741-4630-92de-8b734ddeb037"),
                    Name="Medium"
                },
                  new Difficulty()
                {
                    Id=Guid.Parse("b9669811-b927-4df3-a976-acaa89ecfe1d"),
                    Name="Hard"
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions
            var regions = new List<Region>
            {
                new Region()
                {
                    Id=Guid.Parse("f14e9a4c-c458-4ef1-860e-63c1621f5297"),
                    Name="Auckland",
                    Code="AKL",
                    RegionImageUrl="https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region()
                {
                    Id=Guid.Parse("ac45ea89-ca96-4dab-b6e4-7d74009e8948"),
                    Name="Wellington",
                    Code="WGN",
                    RegionImageUrl="https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region()
                {
                    Id=Guid.Parse("d0117d6c-92c3-4cd1-ba6c-6091cfe21662"),
                    Name="Nelson",
                    Code="NSN",
                    RegionImageUrl="https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                  new Region()
                  {
                    Id=Guid.Parse("e8fd9c69-ec5a-45bd-88b4-6fc7ca6f0f06"),
                    Name="Southland",
                    Code="STL",
                    RegionImageUrl=null
                  },
                  new Region()
                  {
                    Id=Guid.Parse("017c7531-0e24-4d4e-841e-1a2f49aeccb2"),
                    Name="Bay Of Plenty",
                    Code="BOP",
                    RegionImageUrl=null
                  }
            };

            modelBuilder.Entity<Region>().HasData(regions);


        }
    }
}
