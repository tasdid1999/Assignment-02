using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected Context _context;
        protected DbSet<T> _dbset;

        public GenericRepository(Context context)
        {
            this._context = context;
            this._dbset = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize, string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                return await _dbset.FromSqlRaw($"EXEC spGetAll @skip, @take,@tableName", new SqlParameter("@skip", (page - 1) * pageSize), new SqlParameter("@take", pageSize), new SqlParameter("@tableName", tableName)).ToListAsync();
            }

            return new List<T>();
        }

        public async Task<T?> GetById(int id, string tableName)
        {

            if (!string.IsNullOrEmpty(tableName))
            {
                var query = await _dbset.FromSqlRaw($"EXEC spGetById @studentId,@tableName", new SqlParameter("@studentId", id), new SqlParameter("@tableName", tableName)).ToListAsync();

                return query.FirstOrDefault();
            }
            return null;
       
        }

        public async Task InsertAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            
        }

        public async virtual Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);

            if (entity is not null)
            {
                _dbset.Remove(entity);
                return true;
            }

            return false;
        }

       

        public virtual Task UpdateAsync(T entity)
        {
           
            _dbset.Update(entity);

             return Task.CompletedTask;
         
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }
    }
}
