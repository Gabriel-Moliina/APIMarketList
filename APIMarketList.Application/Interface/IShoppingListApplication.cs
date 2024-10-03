using APIMarketList.Domain.DTO.ShoppingList;

namespace APIMarketList.Application.Interface
{
    public interface IShoppingListApplication
    {
        Task<ShoppingListDTO?> Get(int id);
        Task<IList<ShoppingListDTO>> GetAll();
        Task<IList<ShoppingListDTO>> GetByUser(int userId);
    }
}
