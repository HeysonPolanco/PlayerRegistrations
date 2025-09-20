using PlayerRegistrations.Models;
using Microsoft.EntityFrameworkCore;

namespace PlayerRegistrations.DAL;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet <Movements> Movements { get; set; }
    public DbSet<Players> Players { get; set; }
    public DbSet<Matches> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Matches>(entity =>
        {
            entity.HasOne(p => p.Player1)
                  .WithMany()
                  .HasForeignKey(p => p.Player1Id)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Player2)
                  .WithMany()
                  .HasForeignKey(p => p.Player2Id)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Winner)
                  .WithMany()
                  .HasForeignKey(p => p.WinnerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.PlayerTurn)
                  .WithMany()
                  .HasForeignKey(p => p.PlayerTurnId)
                  .OnDelete(DeleteBehavior.Restrict);

        });
    }
}