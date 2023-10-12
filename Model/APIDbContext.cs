using Microsoft.EntityFrameworkCore;

namespace biker.Models
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions option):base(option)
        { }
        public DbSet<Biker> Bikers { get; set; }
        public DbSet<National> Nationals { get; set; }
        public DbSet<Races> Races { get; set; }
        public DbSet<Points> Points { get; set; }
    }
}