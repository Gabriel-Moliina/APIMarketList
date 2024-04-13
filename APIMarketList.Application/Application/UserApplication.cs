using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.UnitOfWork;

namespace APIMarketList.Application.Application
{
    public class UserApplication : BaseApplication, IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
