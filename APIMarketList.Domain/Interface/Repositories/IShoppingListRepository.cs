using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.Repositories.Base;

namespace APIMarketList.Domain.Interface.Repositories
{
    public interface IShoppingListRepository : IBaseRepository<ShoppingList>
    {
        Task<IList<ShoppingList>> GetByUser(int userId);
        Task<bool> Exists(int id);
        Task<bool> IsUserInShoppingList(int shoppingListId, int userId);
    }
}
