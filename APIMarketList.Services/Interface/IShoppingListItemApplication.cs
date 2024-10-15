using APIMarketList.Domain.DTO.ShoppingListItem;

namespace APIMarketList.Application.Interface
{
    public interface IShoppingListItemApplication
    {
        Task AddItem(ShoppingListItemSaveDTO shoppingList);
        Task RemoveItem(int id);
    }
}
