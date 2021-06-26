using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MlbStatsLoader.ConsoleApp.DataObjects;

namespace MlbStatsLoader.ConsoleApp.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("tblPlayers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar(255)");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.Url).IsRequired().HasColumnName("Url").HasColumnType("nvarchar(255)").HasMaxLength(255);
        }
    }
}
