using Microsoft.EntityFrameworkCore;
namespace GamingStore.Models
{
    public class GamingStoreDbContext : DbContext
    {
        public GamingStoreDbContext(DbContextOptions<GamingStoreDbContext>
       options)
        : base(options) { }
        public DbSet<Gaming> Gamings { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
