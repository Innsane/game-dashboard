namespace GameDashboard.Entities;

public class PlaySession
{
    public int Id { get; set; }
    public DateTime Start { get; set; } = DateTime.UtcNow;
    public DateTime End { get; set; } = DateTime.UtcNow;
    public double Seconds => End.Subtract(Start).TotalSeconds;
    public string? Notes { get; set; }
    
    public int UserGameId { get; set; }
    public UserGame UserGame { get; set; } = default!;
}