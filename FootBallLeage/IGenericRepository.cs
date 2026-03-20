using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Leage
{
    internal interface IGenericRepository<T>
    {
        void Add(T entity);
        void Remove(int id);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
