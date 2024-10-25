using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

namespace APIMarketList.Infra.Data.Repositories
{
    public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
    {
        private readonly ICachingService _cachingService;
        public ShoppingListRepository(EntityContext context, ICachingService cachingService) : base(context)
        {
            _cachingService = cachingService;
        }

        public override async Task<IList<ShoppingList>> Get()
        {
            return await _dbSet.AsNoTracking()
                .Include(x => x.Members)
                    .ThenInclude(x => x.User)
                .Include(x => x.ShoppingListItens)
                .ToListAsync();
        }

        public override async Task<ShoppingList?> Get(long id)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Members)
                    .ThenInclude(x => x.User)
                .Include(x => x.ShoppingListItens)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<ShoppingList>> GetByUser(int userId)
        {
            string keyGetByUserCaching = $"{nameof(ShoppingList)}:User:{userId}";

            string cachingShopplingList = await _cachingService.GetAsync(keyGetByUserCaching);
            if (!string.IsNullOrEmpty(cachingShopplingList))
                return JsonSerializer.Deserialize<IList<ShoppingList>>(cachingShopplingList) ?? new List<ShoppingList>();

            var entities = await _dbSet.AsNoTracking()
                .Include(x => x.Members)
                .Where(x => x.Members.Any(x=>x.UserId == userId)).ToListAsync();

            if (entities.Any())
                await _cachingService.SetAsync(keyGetByUserCaching, JsonSerializer.Serialize(entities));

            return entities;
        }

        public async Task<bool> Exists(int id) => await _dbSet.AnyAsync(x => x.Id == id);

        public async Task<bool> IsUserInShoppingList(int shoppingListId, int userId)
        {
            return await _dbSet
                .Where(x => x.Id == shoppingListId)
                    .Include(x => x.Members)
                        .Where(x => x.Members.Any(m => m.UserId == userId)).AnyAsync();
        }
    }
}
