using GameLibrary.Domain.Games;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Persistence;

public class GameLibraryDbContext(DbContextOptions<GameLibraryDbContext> options)
:DbContext(options)
{
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameLibraryDbContext).Assembly);
    }
}