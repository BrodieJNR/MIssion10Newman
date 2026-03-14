using Microsoft.EntityFrameworkCore;

namespace MIssion10Newman.Models
{
    public class BowlingLeagueContext : DbContext
    {
        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map Bowler entity
            modelBuilder.Entity<Bowler>()
                .ToTable("Bowlers")
                .HasKey(b => b.BowlerId);

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerId)
                .HasColumnName("BowlerID");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.TeamId)
                .HasColumnName("TeamID");

            // Map Team entity
            modelBuilder.Entity<Team>()
                .ToTable("Teams")
                .HasKey(t => t.TeamId);

            modelBuilder.Entity<Team>()
                .Property(t => t.TeamId)
                .HasColumnName("TeamID");

            // Configure relationship
            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany(t => t.Bowlers)
                .HasForeignKey(b => b.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
