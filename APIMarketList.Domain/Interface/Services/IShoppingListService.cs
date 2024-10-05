using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Domain.Interface.Services
{
    public interface IShoppingListService
    {
        Task<IList<ShoppingListDTO>> GetAll();
        Task<ShoppingListDTO?> Get(int id);
        Task<IList<ShoppingListDTO>> GetByUser(int userId);
        Task<ShoppingListDTO> CreateNew(ShoppingListSaveDTO shoppingList);
    }
}
