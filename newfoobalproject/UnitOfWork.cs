using Foorball_Leage;
using System.Threading.Tasks;

namespace Foorball_Leage
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly FootballLeagueDbContext _context;
        private IGenericRepository<Team> _teamRepository;
        private IGenericRepository<Coach> _coachRepository;

        public UnitOfWork(FootballLeagueDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Team> Teams => _teamRepository ??= new GenericRepository<Team>(_context);
        public IGenericRepository<Coach> Coaches => _coachRepository ??= new GenericRepository<Coach>(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}