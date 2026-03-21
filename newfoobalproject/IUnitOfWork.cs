using Football_Leage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foorball_Leage
{
    internal interface IUnitOfWork
    {
        IGenericRepository<Team> Teams { get; }
        IGenericRepository<Coach> Coaches { get; }

        void Save();
    }
}
