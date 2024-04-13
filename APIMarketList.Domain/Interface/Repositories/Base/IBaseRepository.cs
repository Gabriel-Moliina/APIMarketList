using APIMarketList.Domain.Interface.Entities;

namespace APIMarketList.Domain.Interface.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<TEntity?> Get(int id);
        Task<IList<TEntity>> Get();
        Task<int> UpdateAsync(TEntity entity);
    }
}
