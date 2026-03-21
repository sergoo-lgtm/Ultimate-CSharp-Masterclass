using Microsoft.EntityFrameworkCore;

namespace Foorball_Leage
{
    internal class FootballLeagueDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=Dr-YOUSEF;Database=FootBallDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}