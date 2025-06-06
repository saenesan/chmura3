using BestTeamAppFull.Models;
using Microsoft.EntityFrameworkCore;

namespace BestTeamAppFull.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Player> Players => Set<Player>();
}
