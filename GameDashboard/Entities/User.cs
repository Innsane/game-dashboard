namespace GameDashboard.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<UserGame> UserGames { get; } = [];
    public List<Game> Games { get; } = [];
}