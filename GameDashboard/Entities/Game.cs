using GameDashboard.Enums;

namespace GameDashboard.Entities;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public Platform Platform { get; set; }
    public DateTime Released { get; set; } = DateTime.UtcNow;
    
    public override string ToString() => $"{Title} ({Released.Year})";

    public List<UserGame> UserGames { get; } = [];
    public List<User> Users { get; } = [];
}