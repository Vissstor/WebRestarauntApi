using RestarauntDAL.Entities;
using RestarauntDAL.Specifications;
using System.Linq.Expressions;

namespace RestarauntDAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllObjectAsync();
        Task<IEnumerable<TEntity>> GetObjectAsync(Specification<TEntity> specification);
        Task<TEntity> GetByIdIncludeAsync(Specification<TEntity> specification);
        Task<TEntity> GetByIdAsync(long id);
        void Delete(TEntity entity);
        Task Create(TEntity entity);
        Task CreateArange(IEnumerable<TEntity> entity);
        Task SaveAsync();
        Task UpdateAsync(TEntity entity);

    }
}
