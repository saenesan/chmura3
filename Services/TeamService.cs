using BestTeamAppFull.Data;
using BestTeamAppFull.Models;
using Microsoft.EntityFrameworkCore;

namespace BestTeamAppFull.Services;

public class TeamService
{
    private readonly AppDbContext _context;
    public TeamService(AppDbContext context) => _context = context;

    public async Task<Team?> GetBestTeamAsync()
    {
        return await _context.Teams
            .Include(t => t.Players)
            .OrderByDescending(t => t.Players.Average(p => p.SkillLevel))
            .FirstOrDefaultAsync();
    }

    public async Task<Player?> GetBestPlayerAsync()
    {
        return await _context.Players
            .OrderByDescending(p => p.SkillLevel)
            .FirstOrDefaultAsync();
    }

    public async Task<Player?> GetBestPlayerAgainstTeamAsync(int teamId)
    {
        var team = await _context.Teams.Include(t => t.Players).FirstOrDefaultAsync(t => t.Id == teamId);
        if (team == null) return null;

        int avg = (int)team.Players.Average(p => p.SkillLevel);
        return await _context.Players
            .Where(p => p.SkillLevel > avg)
            .OrderByDescending(p => p.SkillLevel)
            .FirstOrDefaultAsync();
    }
}
