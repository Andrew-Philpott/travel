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
        //     protected override void OnModelCreating(ModelBuilder builder)
        //     {
        //         builder.Entity<Travel>()
        // }
    }
}
