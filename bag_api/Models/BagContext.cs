
using Microsoft.EntityFrameworkCore;

namespace bag_api.Models
{
    public class BagContext : DbContext
    {
        public BagContext(DbContextOptions<BagContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Bag> Bags { get; set; }
    }
}
