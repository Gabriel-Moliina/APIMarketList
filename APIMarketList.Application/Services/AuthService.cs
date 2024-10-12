using APIMarketList.Application.Application.Base;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Service;
using APIMarketList.Service.Interface;
using AutoMapper;

namespace APIMarketList.Service.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IMapper mapper, INotification notification, ITokenService tokenService) : base(mapper, notification, tokenService)
        {

        }
    }
}
