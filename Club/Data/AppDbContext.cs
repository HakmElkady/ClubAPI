using Club.Model;
using Microsoft.EntityFrameworkCore;

namespace Club.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Clubs> Club { get; set; }
    }
}
