using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Restaraunt.RestarauntSystem.DAL.DbContexts;
using Restaraunt.RestarauntSystem.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace Restaraunt.RestarauntSystem.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public RestarauntContext _context;

        public GenericRepository(RestarauntContext context)
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
            return await IncludeEntities(_context.Set<TEntity>(), includes).ToListAsync();
        }
        //Отримання першого знайденого обєкта 
        public async Task<TEntity> GetOneObjectAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }
        //Отримання всіх обєктів з використання фільтрації  
        public async Task<IEnumerable<TEntity>> GetAfterFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        //Отриманння всіх обєктів та підключенних до нього таблиць
        public async Task<IEnumerable<TEntity>> GetAllInformObjectAfterFilterAsync(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return await IncludeEntities(_context.Set<TEntity>(),includes).Where(predicate).AsQueryable().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> GetByIdIncludeAsync(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            return await IncludeEntities(_context.Set<TEntity>(), includes).FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
 
        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task CreateArange(IEnumerable<TEntity> entity)
        {
            await _context.Set<TEntity>().AddRangeAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        private static IQueryable<TEntity> IncludeEntities(IQueryable<TEntity> query,
     params Expression<Func<TEntity, object>>[] includes)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

      
    }
}
