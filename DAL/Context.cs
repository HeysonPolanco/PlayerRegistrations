using Microsoft.EntityFrameworkCore;
using PlayerRegistrations.Models;

namespace PlayerRegistrations.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Players> Players { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Movements> Movements { get; set; }
    }
}
