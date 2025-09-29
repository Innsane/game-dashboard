using GameDashboard.Enums;

namespace GameDashboard.Dtos;

public class GameDto
{
    public string Title { get; set; }
    public Platform Platform { get; set; }
    public DateTime Released { get; set; }
}
