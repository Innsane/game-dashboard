using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDashboard.Entities.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).IsRequired();
        
        builder.Property(x => x.Platform).IsRequired();
        builder.Property(x => x.Platform).HasConversion<string>();
        
        builder.Property(x => x.Released).IsRequired();
        builder.Property(x => x.Released).HasConversion<string>();
    }
}