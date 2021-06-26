using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MlbStatsLoader.ConsoleApp.DataObjects;

namespace MlbStatsLoader.ConsoleApp.Configurations
{
    public class PlayerStatConfiguration : IEntityTypeConfiguration<PlayerStat>
    {
        public void Configure(EntityTypeBuilder<PlayerStat> builder)
        {
            builder.ToTable("tblPlayerStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.AtBats).IsRequired().HasColumnName("AtBats").HasColumnType("int");
            builder.Property(c => c.BattingAverage).IsRequired().HasColumnName("BA").HasColumnType("float");
            builder.Property(c => c.Hits).IsRequired().HasColumnName("Hits").HasColumnType("int");
            builder.Property(c => c.Obp).IsRequired().HasColumnName("OBP").HasColumnType("float");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.Rbi).IsRequired().HasColumnName("RBI").HasColumnType("int");
            builder.Property(c => c.Runs).IsRequired().HasColumnName("Runs").HasColumnType("int");
            builder.Property(c => c.Slg).IsRequired().HasColumnName("SLG").HasColumnType("float");
            builder.Property(c => c.Strikeouts).IsRequired().HasColumnName("StrikeOuts").HasColumnType("int");
            builder.Property(c => c.Walks).IsRequired().HasColumnName("Walks").HasColumnType("int");
            builder.Property(c => c.GameDate).IsRequired().HasColumnName("GameDate").HasColumnType("date");
        }
    }
}
