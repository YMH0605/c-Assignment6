using System;
using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class BaseRepository<T>: IBaseRepository<T> where T: class
	{
        protected readonly RecruitingDbContext _db;

        public BaseRepository(RecruitingDbContext context)
        {
            _db = context;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

     
        public async Task<int> InsertAsync(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return 1;

        }

        public async Task<int> UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return 1;
        }


        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T,bool>> filter)
        {
            return await _db.Set<T>().Where(filter).ToListAsync();
        }


        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var query = _db.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);
            return await query.Where(where).ToListAsync();
            
        }

        public async Task<bool> GetExistsAsync(Expression<Func<T,bool>>? filter = null)
        {
            if (filter == null) return false;
            return await _db.Set<T>().Where(filter).AnyAsync();
        }
    }
}

