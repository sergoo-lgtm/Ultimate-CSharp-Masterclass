using System;
using System.Collections.Generic;

namespace Football_Leage
{
    internal class CoachService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoachService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCoach(AddCoachDto coachDto)
        {
            try
            {
                var coach = new Coach(coachDto.Name, coachDto.Description);
                _unitOfWork.Coaches.Add(coach);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateCoach(UpdateCoachDto coachDto)
        {
            var coach = _unitOfWork.Coaches.GetById(coachDto.CoachId);

            if (coach == null)
                throw new KeyNotFoundException($"Coach with ID {coachDto.CoachId} not found.");

            coach.UpdateName(coachDto.Name);
            coach.UpdateDescription(coachDto.Description);

            _unitOfWork.Coaches.Update(coach);
        }

        public void DeleteCoach(int id)
        {
            _unitOfWork.Coaches.Remove(id);
        }

        public List<Coach> GetAllCoaches()
        {
            return _unitOfWork.Coaches.GetAll();
        }

        public Coach GetCoachById(int id)
        {
            return _unitOfWork.Coaches.GetById(id);
        }
    }
}