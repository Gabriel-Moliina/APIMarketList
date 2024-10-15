using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Entities;

namespace APIMarketList.Application.Interface
{
    public interface IShoppingListItemApplication
    {
        Task AddItem(ShoppingListItemSaveDTO shoppingList);
        Task RemoveItem(int shoppingListId, int id);
    }
}
