using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MlbStatsLoader.ConsoleApp.DataObjects;

namespace MlbStatsLoader.ConsoleApp.Configurations
{
    public class PitcherStatConfiguration : IEntityTypeConfiguration<PitcherStat>
    {
        public void Configure(EntityTypeBuilder<PitcherStat> builder)
        {
            builder.ToTable("tblPitcherStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.EarnedRunAverage).IsRequired().HasColumnName("EarnedRunAverage").HasColumnType("float");
            builder.Property(c => c.EarnedRuns).IsRequired().HasColumnName("EarnedRuns").HasColumnType("int");
            builder.Property(c => c.Hits).IsRequired().HasColumnName("Hits").HasColumnType("int");
            builder.Property(c => c.HomeRuns).IsRequired().HasColumnName("HomeRuns").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.Innings).IsRequired().HasColumnName("Innings").HasColumnType("float");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.Pitches).IsRequired().HasColumnName("Pitches").HasColumnType("int");
            builder.Property(c => c.PitchesForStrikes).IsRequired().HasColumnName("PitchesForStrikes").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.Runs).IsRequired().HasColumnName("Runs").HasColumnType("int");
            builder.Property(c => c.Strikeouts).IsRequired().HasColumnName("Strikeouts").HasColumnType("int");
            builder.Property(c => c.Walks).IsRequired().HasColumnName("Walks").HasColumnType("int");
            builder.Property(c => c.GameDate).IsRequired().HasColumnName("GameDate").HasColumnType("date");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
        }
    }
}
