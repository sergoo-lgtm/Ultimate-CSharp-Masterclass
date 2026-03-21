using Football_Leage;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foorball_Leage
{
    internal class TeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTeam(AddTeamDto addTeamDto)
        {
            var team = new Team( addTeamDto.Name,addTeamDto.Description);
            _unitOfWork.Teams.Add(team);

        }

        public void UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var team = _unitOfWork.Teams.GetById(updateTeamDto.TeamId);
            team.Update(updateTeamDto.Name, updateTeamDto.Description);
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
