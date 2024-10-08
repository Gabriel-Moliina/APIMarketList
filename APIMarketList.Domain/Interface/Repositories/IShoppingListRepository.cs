using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IShoppingListRepository : IBaseRepository<ShoppingList>
    {
        Task<ShoppingListDTO?> Get(int id);
        Task<IList<ShoppingListDTO>> GetAll();
        Task<IList<ShoppingListDTO>> GetByUser(int userId);
        Task<bool> Exists(int id);
    }
}
