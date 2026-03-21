using Foorball_Leage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foorball_Leage
{
    internal class TeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddTeam(AddTeamDto addTeamDto)
        {
            var team = new Team(addTeamDto.Name, addTeamDto.Description);

            await _unitOfWork.Teams.AddAsync(team);
        }

        public async Task UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var team = await _unitOfWork.Teams.GetByIdAsync(updateTeamDto.TeamId);

            team.Update(updateTeamDto.Name, updateTeamDto.Description);

            await _unitOfWork.Teams.UpdateAsync(team);
        }

        public async Task DeleteTeam(int id)
        {
            await _unitOfWork.Teams.RemoveAsync(id);
        }

        public async Task<List<Team>> GetAllTeams()
        {
            return await _unitOfWork.Teams.GetAllAsync();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _unitOfWork.Teams.GetByIdAsync(id);
        }
        
        
        
        public IQueryable<Team> GetTeamsQuery()
        {
            // دلوقتي ممكن تعمل فلتر أو أوردر قبل التنفيذ
            return _unitOfWork.Teams.Query.OrderBy(t => t.Name);
        }
    }
}