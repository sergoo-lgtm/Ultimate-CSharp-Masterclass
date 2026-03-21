namespace Football_Leage;

internal class UnitOfWork:IUnitOfWork
{
    private readonly FootballLeageDBContect  _context;

    public IGenericRepository<Coach> Coaches { get; private set; }
    public IGenericRepository<Team> Teams { get; private set; }
    public UnitOfWork(FootballLeageDBContect context)
    {
        _context = context;

        Coaches = new GenericRepository<Coach>(_context);
        Teams = new GenericRepository<Team>(_context);
    }
    public void Save()
    {
        _context.SaveChanges();
    }
}