using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Services;
using System.Transactions;

namespace APIMarketList.Services.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListApplication _shoppingListApplication;
        public ShoppingListService(IShoppingListApplication shoppingListApplication)
        {
            _shoppingListApplication = shoppingListApplication;
        }

        public async Task<ShoppingListDTO?> Get(int id) => await _shoppingListApplication.Get(id);
        public async Task<IList<ShoppingListDTO>> GetAll() => await _shoppingListApplication.GetAll();
        public async Task<IList<ShoppingListDTO>> GetByUser(int userId) => await _shoppingListApplication.GetByUser(userId);
        public async Task<ShoppingListDTO> CreateNew(ShoppingListSaveDTO shoppingList)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            ShoppingListDTO response = await _shoppingListApplication.CreateNew(shoppingList);
            transaction.Complete();

            return response;
        }
    }
}
