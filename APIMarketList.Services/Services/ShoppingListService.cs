using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Services;

namespace APIMarketList.Services.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListApplication _shoppingApplication;
        public ShoppingListService(IShoppingListApplication shoppingApplication)
        {
            _shoppingApplication = shoppingApplication;
        }

        public async Task<ShoppingListDTO> Get(int id) => await _shoppingApplication.Get(id);
        public async Task<IList<ShoppingListDTO>> GetAll() => await _shoppingApplication.GetAll();
        public async Task<IList<ShoppingListDTO>> GetByUser(int userId) => await _shoppingApplication.GetByUser(userId);
    }
}
