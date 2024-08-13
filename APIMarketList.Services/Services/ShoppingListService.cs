using APIMarketList.Application.Interface;
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
    }
}
