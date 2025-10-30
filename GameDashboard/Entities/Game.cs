using GameDashboard.Enums;

namespace GameDashboard.Entities;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public Platform Platform { get; set; }
    public DateTime Released { get; set; }
    
    public List<UserGame> UserGames { get; } = [];
    public List<User> Users { get; } = [];
    
    public override string ToString() => $"{Title} ({Released.Year})";
}