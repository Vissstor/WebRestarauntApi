using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.DbContexts;
using System.Linq.Expressions;

namespace RestarauntDAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
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
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> GetByIdIncludeAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return await IncludeEntities(_context.Set<TEntity>(), includes).FirstOrDefaultAsync(predicate);
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
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
