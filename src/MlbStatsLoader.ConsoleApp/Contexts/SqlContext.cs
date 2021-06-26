using Microsoft.EntityFrameworkCore;
using MlbStatsLoader.ConsoleApp.Configurations;
using MlbStatsLoader.ConsoleApp.DataObjects;

namespace MlbStatsLoader.ConsoleApp.Contexts
{
    public class SqlContext : DbContext
    {
        private readonly string connString;
        public SqlContext(string connectionString)
        {
            this.connString = connectionString;
        }

        public SqlContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStat> PlayerStats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PitcherStat> PitchingStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(connString))
            {                
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerStatConfiguration());
            modelBuilder.ApplyConfiguration(new PitcherStatConfiguration());
        }
    }
}
