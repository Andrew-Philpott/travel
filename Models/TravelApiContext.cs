using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public TravelApiContext(DbContextOptions<TravelApiContext> options)
                    : base(options)
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>().HasData(
                new Destination { DestinationId = 1, Country = "Italy", City = "Venice" },
                 new Destination { DestinationId = 2, Country = "Spain", City = "Madrid" },
                  new Destination { DestinationId = 3, Country = "Germany", City = "Berin" },
                   new Destination { DestinationId = 4, Country = "Africa", City = "Lagos" },
                    new Destination { DestinationId = 5, Country = "United States", City = "Washington" },
                     new Destination { DestinationId = 6, Country = "France", City = "Paris" }
            );
            builder.Entity<Review>().HasData(
                new Review { ReviewId = 1, ReviewerName = "Andriy", Description = "Awesome place", Rating = 5, DestinationId = 1 },
                 new Review { ReviewId = 2, ReviewerName = "Andriy", Description = "Better places", Rating = 3, DestinationId = 2 },
                  new Review { ReviewId = 3, ReviewerName = "Andrew", Description = "Great except for...", Rating = 4, DestinationId = 3 },
                   new Review { ReviewId = 4, ReviewerName = "Andrew", Description = "Awesome place", Rating = 5, DestinationId = 3 }, new Review { ReviewId = 5, ReviewerName = "Andriy", Description = "Awesome place", Rating = 5, DestinationId = 4 },
                    new Review { ReviewId = 6, ReviewerName = "Andriy", Description = "Awesome place", Rating = 5, DestinationId = 5 }
            );
        }
    }
}
