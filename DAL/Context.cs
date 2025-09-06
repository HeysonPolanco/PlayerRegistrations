using PlayerRegistrations.Models;
using Microsoft.EntityFrameworkCore;

namespace PlayerRegistrations.DAL;
public class Context : DbContext
{
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Players> Players { get; set; }
}