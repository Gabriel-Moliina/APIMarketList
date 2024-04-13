using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.UnitOfWork;

namespace APIMarketList.Application.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
