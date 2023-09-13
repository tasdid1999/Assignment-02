using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetById(int id);
        
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

    }
}
