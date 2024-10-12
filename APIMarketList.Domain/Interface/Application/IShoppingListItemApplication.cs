using APIMarketList.Domain.DTO.ShoppingListItem;

namespace APIMarketList.Domain.Interface.Application
{
    public interface IShoppingListItemApplication
    {
        Task AddItem(ShoppingListItemSaveDTO shoppingList);
        Task RemoveItem(int id);
    }
}
