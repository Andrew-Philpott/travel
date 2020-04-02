using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TravelClient.Models
{
    public class TravelClientContext : IdentityDbContext<ApplicationUser>
    {
        public TravelClientContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TravelClient.Models.Destination> Destinations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Destination>().HasData(
                new Destination { DestinationId = 1, Country = "Italy", City = "Venice" },
                new Destination { DestinationId = 2, Country = "Spain", City = "Madrid" },
                new Destination { DestinationId = 3, Country = "Germany", City = "Berlin" },
                new Destination { DestinationId = 4, Country = "Nigeria", City = "Lagos" },
                new Destination { DestinationId = 5, Country = "United States", City = "Washington" },
                new Destination { DestinationId = 6, Country = "France", City = "Paris" },
                new Destination { DestinationId = 7, Country = "United States", City = "Paris" },
                new Destination { DestinationId = 8, Country = "United States", City = "Berlin" },
                new Destination { DestinationId = 9, Country = "Ukraine", City = "Kyiv" }
            );
            //most reviewed and highest rating
            //most reviewed will be destination id = 5 so us wash
            //highest rating will be the one with 5 which is nigeria lagos
            builder.Entity<Review>().HasData(
                new Review { ReviewId = 1, ReviewerName = "Andriy", Description = "Awesome place", Rating = 5, DestinationId = 1 },
                new Review { ReviewId = 2, ReviewerName = "Andriy", Description = "Better places", Rating = 3, DestinationId = 2 },
                new Review { ReviewId = 3, ReviewerName = "Andrew", Description = "Great except for...", Rating = 4, DestinationId = 3 },
                new Review { ReviewId = 4, ReviewerName = "Andrew", Description = "Awesome place", Rating = 4, DestinationId = 3 },
                new Review { ReviewId = 5, ReviewerName = "Andriy", Description = "Awesome place", Rating = 5, DestinationId = 4 },
                new Review { ReviewId = 6, ReviewerName = "Andriy", Description = "A lot of museums", Rating = 4, DestinationId = 5 },
                new Review { ReviewId = 7, ReviewerName = "Adela", Description = "City with great history", Rating = 5, DestinationId = 5 },

                new Review { ReviewId = 8, ReviewerName = "Krista", Description = "Weather could be better", Rating = 4, DestinationId = 1 },
                new Review { ReviewId = 9, ReviewerName = "Tiffany", Description = "Nice place to live", Rating = 4, DestinationId = 5 },
                new Review { ReviewId = 10, ReviewerName = "Steven", Description = "Missing California", Rating = 3, DestinationId = 5 },
                new Review { ReviewId = 11, ReviewerName = "Jack", Description = "Far from ocean", Rating = 2, DestinationId = 5 },

                new Review { ReviewId = 12, ReviewerName = "Jiwon", Description = "Best city in Texas", Rating = 4, DestinationId = 7 },
                new Review { ReviewId = 13, ReviewerName = "Leilani", Description = "Actually we call it New Berlin", Rating = 3, DestinationId = 8 }
            );
        }
    }
}
