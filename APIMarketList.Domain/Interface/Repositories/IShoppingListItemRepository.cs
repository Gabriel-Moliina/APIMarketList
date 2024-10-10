using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IShoppingListItemRepository : IBaseRepository<ShoppingListItem>
    {
        Task<ShoppingListItem?> GetByIndexShoppingListId(int index, int shoppingListId);
    }
}
