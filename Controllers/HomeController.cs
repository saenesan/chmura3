using BestTeamAppFull.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestTeamAppFull.Controllers;

public class HomeController : Controller
{
    private readonly TeamService _teamService;
    public HomeController(TeamService teamService) => _teamService = teamService;

    public async Task<IActionResult> Index()
    {
        var bestTeam = await _teamService.GetBestTeamAsync();
        var bestPlayer = await _teamService.GetBestPlayerAsync();
        var bestVsTeam = await _teamService.GetBestPlayerAgainstTeamAsync(bestTeam?.Id ?? 0);

        ViewBag.BestTeam = bestTeam?.Name ?? "N/A";
        ViewBag.BestPlayer = bestPlayer?.Name ?? "N/A";
        ViewBag.BestVsTeam = bestVsTeam?.Name ?? "N/A";

        return View();
    }
}
