using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories.Base;

namespace APIMarketList.Infra.Data.Repositories
{
    public class ShoppingListItemRepository : BaseRepository<ShoppingListItem>, IShoppingListItemRepository
    {
        public ShoppingListItemRepository(EntityContext context) : base(context)
        {
        }
    }
}
