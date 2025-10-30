using System.Collections.ObjectModel;
using GameDashboard.Enums;

namespace GameDashboard.Entities;

public class UserGame
{
    public int Id { get; set; }
    public GameState State { get; set; } = GameState.Future;
    public int? Rating { get; set; } // 1..10
    public string? Review { get; set; } // public
    public string? Notes { get; set; } // private
    
    public int UserId { get; set; }
    public User User { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; } = default!;
    public ICollection<PlaySession> Sessions { get; } = new Collection<PlaySession>();
}