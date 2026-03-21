using System;
using System.Collections.Generic;
using System.Text;

namespace Foorball_Leage
{
    internal interface IGenericRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
