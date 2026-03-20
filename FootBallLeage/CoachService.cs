using System;
using System.Collections.Generic;

namespace Football_Leage
{
    internal class CoachService
    {
        private readonly IGenericRepository<Coach> _coachRepo;

        public CoachService(IGenericRepository<Coach> coachRepo)
        {
            _coachRepo = coachRepo;
        }

        public void AddCoach(AddCoachDto coachDto)
        {
            try
            {
                var coach = new Coach(coachDto.Name, coachDto.Description);
                _coachRepo.Add(coach);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateCoach(UpdateCoachDto coachDto)
        {
            var coach = _coachRepo.GetById(coachDto.CoachId);

            if (coach == null)
                throw new KeyNotFoundException($"Coach with ID {coachDto.CoachId} not found.");

            coach.UpdateName(coachDto.Name);
            coach.UpdateDescription(coachDto.Description);

            _coachRepo.Update(coach);
        }

        public void DeleteCoach(int id)
        {
            _coachRepo.Remove(id);
        }

        public List<Coach> GetAllCoaches()
        {
            return _coachRepo.GetAll();
        }

        public Coach GetCoachById(int id)
        {
            return _coachRepo.GetById(id);
        }
    }
}