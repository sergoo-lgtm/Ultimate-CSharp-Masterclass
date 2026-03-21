using Football_Leage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foorball_Leage
{
    internal class CoachService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoachService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCoach(AddCoachDto  addCoachDto)
        {
            var coach = new Coach(addCoachDto.Name, addCoachDto.Description);
            _unitOfWork.Coaches.Add(coach);

        }

        public void UpdateCoach(UpdateCoachDto updateCoachDto)
        {
            var coach = _unitOfWork.Coaches.GetById(updateCoachDto.CoachId);
            coach.Update(updateCoachDto.Name, updateCoachDto.Description);
            _unitOfWork.Coaches.Update(coach);

        }
        public void DeleteCoach(int id)
        {
            _unitOfWork.Coaches.Remove(id);
        }

        public List<Coach> GetAllCoach()
        {
            return _unitOfWork.Coaches.GetAll();
        }

        public Coach GetCoachById(int id)
        {
            return _unitOfWork.Coaches.GetById(id);
        }
    }
}
