namespace Football_Leage;

internal interface IUnitOfWork
{
    IGenericRepository<Coach> Coaches { get; }
    IGenericRepository<Team> Teams { get; }

    void Save();
}