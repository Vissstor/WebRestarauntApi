using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.DbContexts;
using System;
using System.Linq.Expressions;

namespace Restaraunt.RestarauntSystem.DAL.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        DbContext _context;

        public GenericRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            _context = context;
        }
        //Отримання всіх обєктів
        public async Task<IEnumerable<TEntity>> GetAllObjectAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        //Отримання всіх обєктів з підключенням інших таблиць
        public async Task<IEnumerable<TEntity>> GetAllInformationObjectAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await IncludeEntities<TEntity>(_context.Set<TEntity>(), includes).ToListAsync();
        }
        //Отримання першого знайденого обєкта 
        public async Task<TEntity> GetOneObjectAsync(Expression<Func<TEntity, object>>[] includes)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync();
        }
        //Отримання всіх обєктів з використання фільтрації  
        public async Task<IEnumerable<TEntity>> GetAfterFilterAsync(Func<TEntity, bool> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).AsQueryable().ToListAsync();
        }
        //Отриманння всіх обєктів та підключенних до нього таблиць
        public async Task<IEnumerable<TEntity>> GetAllInformObjectAfterFilterAsync(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return await IncludeEntities<TEntity>(_context.Set<TEntity>().Where(predicate).AsQueryable(),includes).ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
 
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        private static IQueryable<TEntity> IncludeEntities<TEntity>(IQueryable<TEntity> query,
     params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
