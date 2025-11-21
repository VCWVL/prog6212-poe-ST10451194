using Microsoft.EntityFrameworkCore;

namespace PROG_POE.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        // Add other tables if needed
        public DbSet<Claim> Claims { get; set; }
    }
}
