using System;
using System.Collections.Generic;

namespace Football_Leage
{
    internal class TeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTeam(AddTeamDto teamDto)
        {
            try
            {
                var team = new Team(teamDto.Name, teamDto.Description);
                _unitOfWork.Teams.Add(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateTeam(UpdateTeamDTO teamDto)
        {
            var team = _unitOfWork.Teams.GetById(teamDto.TeamId);

            if (team == null)
                throw new KeyNotFoundException($"Team with ID {teamDto.TeamId} not found");

            team.UpdateName(teamDto.Name);
            team.UpdateDescription(teamDto.Description);

            _unitOfWork.Teams.Update(team);
        }

        public void DeleteTeam(int id)
        {
            _unitOfWork.Teams.Remove(id);
        }

        public List<Team> GetAllTeams()
        {
            return _unitOfWork.Teams.GetAll();
        }

        public Team GetTeamById(int id)
        {
            return _unitOfWork.Teams.GetById(id);
        }
    }
}