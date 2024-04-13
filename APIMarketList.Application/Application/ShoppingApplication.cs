using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.UnitOfWork;

namespace APIMarketList.Application.Application
{
    public class ShoppingApplication : BaseApplication, IShoppingApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
