using APIMarketList.Domain.DTO.Member;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APIMarketList.Infra.Data.Repositories
{
    public class ShoppingListItemRepository : BaseRepository<ShoppingListItem>, IShoppingListItemRepository
    {
        public ShoppingListItemRepository(EntityContext context) : base(context)
        {
        }

        public async Task<ShoppingListItem?> GetByIndexShoppingListId(int index, int shoppingListId) =>
            await _dbSet.FirstOrDefaultAsync(x => x.Index == index && x.ShoppingListId == shoppingListId);
    }
}
