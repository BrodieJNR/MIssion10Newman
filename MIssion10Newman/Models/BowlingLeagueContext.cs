using Microsoft.EntityFrameworkCore;

namespace MIssion10Newman.Models
{
    public class BowlingLeagueContext : DbContext
    {
        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Team entity
            modelBuilder.Entity<Team>()
                .ToTable("Teams")
                .HasKey(t => t.TeamId);

            modelBuilder.Entity<Team>()
                .Property(t => t.TeamId)
                .HasColumnName("TeamID");

            modelBuilder.Entity<Team>()
                .Property(t => t.TeamName)
                .HasColumnName("TeamName");

            // Configure Bowler entity
            modelBuilder.Entity<Bowler>()
                .ToTable("Bowlers")
                .HasKey(b => b.BowlerId);

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerId)
                .HasColumnName("BowlerID");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerFirstName)
                .HasColumnName("BowlerFirstName");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerLastName)
                .HasColumnName("BowlerLastName");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerMiddleInit)
                .HasColumnName("BowlerMiddleInit");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerAddress)
                .HasColumnName("BowlerAddress");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerCity)
                .HasColumnName("BowlerCity");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerState)
                .HasColumnName("BowlerState");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerZip)
                .HasColumnName("BowlerZip");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerPhoneNumber)
                .HasColumnName("BowlerPhoneNumber");

            modelBuilder.Entity<Bowler>()
                .Property(b => b.TeamId)
                .HasColumnName("TeamID");

            // Configure the relationship
            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany(t => t.Bowlers)
                .HasForeignKey(b => b.TeamId);
        }
    }
}
