using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.Entities;
using APIMarketList.Domain.Interface.UnitOfWork;

namespace APIMarketList.Application.Application
{
    public class ProductApplication : BaseApplication<Product>, IProductApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
