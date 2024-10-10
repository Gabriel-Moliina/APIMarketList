using APIMarketList.Application.Interface.Base;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Services;
using AutoMapper;

namespace APIMarketList.Application.Application.Base
{
    public class BaseApplication : IBaseApplication
    {
        protected readonly IMapper _mapper;
        protected readonly INotification _notification;
        protected readonly ITokenService _tokenService;
        public BaseApplication(IMapper mapper,
            INotification notification,
            ITokenService tokenService)
        {                      
            _mapper = mapper;
            _notification = notification;
            _tokenService = tokenService;
        }
    }
}
