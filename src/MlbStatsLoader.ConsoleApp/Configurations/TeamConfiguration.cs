using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MlbStatsLoader.ConsoleApp.DataObjects;

namespace MlbStatsLoader.ConsoleApp.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("tblTeams");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
            builder.Property(c => c.Code).IsRequired().HasColumnName("Code").HasColumnType("nvarchar(5)").HasMaxLength(5);
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar(150)").HasMaxLength(150);
        }
    }
}
