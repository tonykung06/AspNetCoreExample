using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExample.Entities
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
