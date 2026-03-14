using Microsoft.EntityFrameworkCore;
using MIssion10Newman.Models;

namespace MIssion10Newman.Data;

public class BowlingContext : DbContext
{
    public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

    public DbSet<Bowler> Bowlers { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>().ToTable("Bowlers");
        modelBuilder.Entity<Team>().ToTable("Teams");
    }
}