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
            if (string.IsNullOrWhiteSpace(coachDto.Name))
            {
                Console.WriteLine("Coach name is required");
                return;
            }

            var coach = new Coach
            {
                Name = coachDto.Name,
                CreationDate = DateTime.Now
            };

            _coachRepo.Add(coach);
        }

        public void UpdateCoach(UpdateCoachDto coachDto)
        {
            var coach = _coachRepo.GetById(coachDto.CoachId);
            if (coach == null)
            {
                throw new KeyNotFoundException($"Team with ID {coachDto.CoachId} not found.");

            }

            coach.Name = coachDto.Name;
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