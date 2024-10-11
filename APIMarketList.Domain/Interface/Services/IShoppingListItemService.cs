using APIMarketList.Domain.DTO.ShoppingListItem;

namespace APIMarketList.Domain.Interface.Services
{
    public interface IShoppingListItemService
    {
        Task AddItem(ShoppingListItemSaveDTO shoppingList);
        Task RemoveItem(int id);
    }
}
