using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foorball_Leage
{
    internal class CoachService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoachService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCoach(AddCoachDto addCoachDto)
        {
            var coach = new Coach(addCoachDto.Name, addCoachDto.Description);
            await _unitOfWork.Coaches.AddAsync(coach);
        }

        public async Task UpdateCoach(UpdateCoachDto updateCoachDto)
        {
            var coach = await _unitOfWork.Coaches.GetByIdAsync(updateCoachDto.CoachId);
            coach.Update(updateCoachDto.Name, updateCoachDto.Description);
            await _unitOfWork.Coaches.UpdateAsync(coach);
        }

        public async Task DeleteCoach(int id)
        {
            await _unitOfWork.Coaches.RemoveAsync(id);
        }

        public async Task<List<Coach>> GetAllCoach()
        {
            return await _unitOfWork.Coaches.GetAllAsync();
        }

        public async Task<Coach> GetCoachById(int id)
        {
            return await _unitOfWork.Coaches.GetByIdAsync(id);
        }
        
        
        
        public IQueryable<Coach> GetCoachesQuery()
        {
            return _unitOfWork.Coaches.Query.OrderBy(c => c.Name);
        }
    }
}