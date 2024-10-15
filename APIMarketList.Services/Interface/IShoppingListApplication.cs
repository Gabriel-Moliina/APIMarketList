using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Application.Interface
{
    public interface IShoppingListApplication
    {
        Task<IList<ShoppingListDTO>> GetAll();
        Task<ShoppingListDTO?> Get(int id);
        Task<IList<ShoppingListDTO>> GetByUser(int userId);
        Task<ShoppingListSaveResponseDTO> CreateNew(ShoppingListSaveDTO shoppingList);
        Task Delete(int id);
    }
}
