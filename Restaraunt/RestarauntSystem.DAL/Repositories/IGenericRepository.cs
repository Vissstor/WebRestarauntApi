using System.Linq.Expressions;

namespace Restaraunt.RestarauntSystem.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllObjectAsync();
        Task<IEnumerable<TEntity>> GetAllInformationObjectAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetOneObjectAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAfterFilterAsync(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAllInformObjectAfterFilterAsync(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(long id);
        void Delete(TEntity entity);
        void Create(TEntity entity);
         Task SaveAsync();

    }
}
