using System;
using System.Collections.Generic;

namespace Football_Leage
{
    internal class TeamService
    {
        private readonly IGenericRepository<Team> _teamRepo;

        public TeamService(IGenericRepository<Team> teamRepo)
        {
            _teamRepo = teamRepo;
        }

        public void AddTeam(AddTeamDto teamDto)
        {
            if (string.IsNullOrWhiteSpace(teamDto.Name))
            {
                Console.WriteLine("Team name is required");
                return;
            }

            var team = new Team
            {
                Name = teamDto.Name,
                CreationDate = DateTime.Now
            };

            _teamRepo.Add(team);
        }
        public void UpdateTeam(UpdateTeamDTO teamDto)
        {
            var team = _teamRepo.GetById(teamDto.TeamId);
            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {teamDto.TeamId} not found.");

            }

            team.Name = teamDto.Name;
            _teamRepo.Update(team);
        }

        public void DeleteTeam(int id)
        {
            _teamRepo.Remove(id);
        }

        public List<Team> GetAllTeams()
        {
            return _teamRepo.GetAll();
        }

        public Team GetTeamById(int id)
        {
            return _teamRepo.GetById(id);
        }
    }
}