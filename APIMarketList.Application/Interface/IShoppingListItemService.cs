using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;

namespace APIMarketList.Service.Interface
{
    public interface IShoppingListItemService
    {
        Task AddItem(ShoppingListItemSaveDTO saveShoppingListItemDTO);
        Task RemoveItem(int id);
    }
}
