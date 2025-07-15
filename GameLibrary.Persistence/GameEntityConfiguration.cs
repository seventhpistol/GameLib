using GameLibrary.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Persistence;

public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedNever();
        builder.Property(g => g.Title).IsRequired();
        builder.Property(g => g.Price).IsRequired().HasPrecision(2);
        builder.Property(g => g.ReleaseDate).IsRequired();
    }
}