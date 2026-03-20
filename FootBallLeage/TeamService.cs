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
            try
            {
                var team = new Team(teamDto.Name, teamDto.Description);
                _teamRepo.Add(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateTeam(UpdateTeamDTO teamDto)
        {
            var team = _teamRepo.GetById(teamDto.TeamId);

            if (team == null)
                throw new KeyNotFoundException($"Team with ID {teamDto.TeamId} not found");

            team.UpdateName(teamDto.Name);
            team.UpdateDescription(teamDto.Description);

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