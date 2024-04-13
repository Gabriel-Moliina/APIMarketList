using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.Services;

namespace APIMarketList.Services.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IShoppingApplication _shoppingApplication;
        public ShoppingService(IShoppingApplication shoppingApplication)
        {
            _shoppingApplication = shoppingApplication;
        }
    }
}
