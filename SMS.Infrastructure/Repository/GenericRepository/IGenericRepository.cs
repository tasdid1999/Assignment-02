using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(int page , int pageSize , string proccedureName);

        Task<T?> GetById(int id,string proccedureName);
        
        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);

    }
}
