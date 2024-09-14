using APIMarketList.Domain.Entities;
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
            FillDatesChange(entity);
            var newEntity = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> Get(long id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IList<TEntity>> Get() => await _dbSet.ToListAsync();

        public async Task<int> UpdateAsync(TEntity entity)
        {
            FillDatesChange(entity);
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<TEntity> SaveOrUpdate(TEntity entity)
        {
            if (entity.Id == 0)
                return await AddAsync(entity);

            await UpdateAsync(entity);
            return entity;
        }

        private void FillDatesChange(TEntity entity)
        {
            if(entity.Id == 0)
                _context.Entry(entity).Property("IncludedDate").CurrentValue = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
        }
    }
}
