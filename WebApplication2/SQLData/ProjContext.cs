using Microsoft.EntityFrameworkCore;

namespace WebApplication2.SQLData
{
    public class ProjContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ProjContext(DbContextOptions options) : base(options) { }
    }
}
