using GameDashboard.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameDashboard.Database;

public class AppDbContext : DbContext
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<PlaySession> PlaySessions => Set<PlaySession>();
    public DbSet<UserGame> UserGames => Set<UserGame>();
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}