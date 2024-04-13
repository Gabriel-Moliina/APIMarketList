using APIMarketList.Domain.Entities.Base;
using APIMarketList.Domain.Interface.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;
using APIMarketList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace APIMarketList.Infra.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly EntityContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(EntityContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var newEntity = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> Get(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IList<TEntity>> Get() => await _dbSet.ToListAsync();

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
