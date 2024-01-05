using Microsoft.EntityFrameworkCore;
using techavidus_task1_API.Model;

namespace techavidus_task1_API
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        // Define a DbSet for your User model
        public DbSet<User> Users { get; set; }
    }
}
