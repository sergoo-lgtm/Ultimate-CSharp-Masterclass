using Foorball_Leage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foorball_Leage

{
    internal interface IUnitOfWork
    {
        IGenericRepository<Team> Teams { get; }
        IGenericRepository<Coach> Coaches { get; }
        Task SaveChangesAsync();
    }

}
