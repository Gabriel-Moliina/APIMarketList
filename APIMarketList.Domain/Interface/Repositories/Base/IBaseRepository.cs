using APIMarketList.Domain.Interface.Entities;

namespace APIMarketList.Domain.Interface.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<TEntity?> Get(long id);
        Task<IList<TEntity>> Get();
        Task<int> UpdateAsync(TEntity entity);
        Task<TEntity> SaveOrUpdate(TEntity entity);
    }
}
