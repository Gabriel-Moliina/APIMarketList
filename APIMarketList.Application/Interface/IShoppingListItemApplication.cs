using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;

namespace APIMarketList.Application.Interface
{
    public interface IShoppingListItemApplication
    {
        Task AddItem(ShoppingListItemSaveDTO saveShoppingListItemDTO);
        Task RemoveItem(int id);
    }
}
