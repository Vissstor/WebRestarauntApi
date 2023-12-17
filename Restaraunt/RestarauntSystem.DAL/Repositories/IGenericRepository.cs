using Restaraunt.RestarauntSystem.DAL.Entities;
using System.Linq.Expressions;

namespace Restaraunt.RestarauntSystem.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllObjectAsync();
        Task<IEnumerable<TEntity>> GetAllInformationObjectAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetOneObjectAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAfterFilterAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllInformObjectAfterFilterAsync(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(long id);
        Task<TEntity> GetByIdIncludeAsync(long id, params Expression<Func<TEntity, object>>[] includes);
        void Delete(TEntity entity);
        Task Create(TEntity entity);
        Task CreateArange(IEnumerable<TEntity> entity);
        Task SaveAsync();

    }
}
