namespace BestTeamAppFull.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int SkillLevel { get; set; }
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}
