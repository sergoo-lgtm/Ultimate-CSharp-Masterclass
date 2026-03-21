using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foorball_Leage
{
    internal interface IGenericRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        
        
        
        ///////
        ///
        ///
        ///
        IQueryable<T> Query { get; }

    }
}
