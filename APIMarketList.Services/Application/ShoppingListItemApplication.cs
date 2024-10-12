using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Interface.Application;
using APIMarketList.Service.Interface;
using System.Transactions;

namespace APIMarketList.Application.Application
{
    public class ShoppingListItemApplication : IShoppingListItemApplication
    {
        private readonly IShoppingListItemService _shoppingListItemService;
        public ShoppingListItemApplication(IShoppingListItemService shoppingListItemService)
        {
            _shoppingListItemService = shoppingListItemService;
        }

        public async Task AddItem(ShoppingListItemSaveDTO shoppingList)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _shoppingListItemService.AddItem(shoppingList);
            transaction.Complete();
        }

        public async Task RemoveItem(int id)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _shoppingListItemService.RemoveItem(id);
            transaction.Complete();
        }
    }
}
