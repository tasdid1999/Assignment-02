using Microsoft.EntityFrameworkCore;
using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async virtual Task InsertAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            
        }

        public async virtual Task DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);

            if (entity is not null)
            {
                _dbset.Remove(entity);
            }
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
            
        }

        public async virtual Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public virtual Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
