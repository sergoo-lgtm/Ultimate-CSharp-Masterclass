using Football_Leage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foorball_Leage
{
    internal class FootballLLeageDbContext: DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Dr-YOUSEF;Database=FootBallDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
