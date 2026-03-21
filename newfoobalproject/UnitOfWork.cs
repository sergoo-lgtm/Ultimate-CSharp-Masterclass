using Football_Leage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foorball_Leage
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly FootballLLeageDbContext _context;

        private IGenericRepository<Team> _teamRepository;
        private IGenericRepository<Coach> _coachRepository;



        public UnitOfWork(FootballLLeageDbContext context)
        {
            _context = context;
            
        }
        public IGenericRepository<Team> Teams
    => _teamRepository ??= new GenericRepository<Team>(_context);

        public IGenericRepository<Coach> Coaches
            => _coachRepository ??= new GenericRepository<Coach>(_context);
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
