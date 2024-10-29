using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIMarketList.Infra.Data.Repositories
{
    public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(EntityContext context) : base(context)
        {
            
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
            return await _dbSet.AsNoTracking()
                .Include(x => x.Members)
                .Where(x => x.Members.Any(x=>x.UserId == userId)).ToListAsync();
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
