using APIMarketList.Application.Application;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.Interface.Services;
using System.Transactions;

namespace APIMarketList.Services.Services
{
    public class ShoppingListItemService : IShoppingListItemService
    {
        private readonly IShoppingListItemApplication _shoppingListItemApplication;
        public ShoppingListItemService(IShoppingListItemApplication shoppingListItemApplication)
        {
            _shoppingListItemApplication = shoppingListItemApplication;
        }

        public async Task AddItem(ShoppingListItemSaveDTO shoppingList)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _shoppingListItemApplication.AddItem(shoppingList);
            transaction.Complete();
        }

        public async Task RemoveItem(ShoppingListItemRemoveDTO removeShoppingListItemDTO)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);

            await _shoppingListItemApplication.RemoveItem(removeShoppingListItemDTO);
            transaction.Complete();
        }
    }
}
