using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Application;
using APIMarketList.Service.Interface;
using System.Transactions;

namespace APIMarketList.Application.Application
{
    public class ShoppingListApplication : IShoppingListApplication
    {
        private readonly IShoppingListService _shoppingListService;
        public ShoppingListApplication(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        public async Task<ShoppingListDTO?> Get(int id) => await _shoppingListService.Get(id);
        public async Task<IList<ShoppingListDTO>> GetAll() => await _shoppingListService.GetAll();
        public async Task<IList<ShoppingListDTO>> GetByUser(int userId) => await _shoppingListService.GetByUser(userId);
        public async Task<ShoppingListSaveResponseDTO> CreateNew(ShoppingListSaveDTO shoppingList)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            ShoppingListSaveResponseDTO response = await _shoppingListService.CreateNew(shoppingList);
            transaction.Complete();

            return response;
        }
        
        public async Task Delete(int id)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            
            await _shoppingListService.Delete(id);

            transaction.Complete();
        }
    }
}
