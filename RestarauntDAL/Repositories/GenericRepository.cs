using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.DbContexts;
using RestarauntDAL.Entities;
using RestarauntDAL.Specifications;
using System.Linq;
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

        public async Task<IEnumerable<TEntity>> GetAllObjectAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetObjectAsync(Specification<TEntity> specification)
        {
            return await Specification(_context.Set<TEntity>(), specification).ToListAsync();
        }
        
        public async Task<TEntity> GetByIdIncludeAsync(Specification<TEntity> specification)
        {
            return await Specification(_context.Set<TEntity>(), specification).FirstOrDefaultAsync();
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
    
        protected IQueryable<TEntity> Specification(IQueryable<TEntity> queryable,Specification<TEntity> specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            if (queryable == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (specification.CustomCondition != null)
            {
                queryable = queryable.Where(specification.CustomCondition);
            }

            if (specification.CustomIncludes != null)
            {
                foreach (var includeExpression in specification.CustomIncludes)
                {
                    queryable = queryable.Include(includeExpression);
                }
            }

            return queryable;
        }

    }
}
