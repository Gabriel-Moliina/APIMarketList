using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.Services;

namespace APIMarketList.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserApplication _userApplication;
        public UserService(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }


    }
}
