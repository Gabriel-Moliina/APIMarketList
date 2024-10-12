using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Service;
using APIMarketList.Service.Interface.Base;
using AutoMapper;

namespace APIMarketList.Application.Application.Base
{
    public class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;
        protected readonly INotification _notification;
        protected readonly ITokenService _tokenService;
        public BaseService(IMapper mapper,
            INotification notification,
            ITokenService tokenService)
        {                      
            _mapper = mapper;
            _notification = notification;
            _tokenService = tokenService;
        }
    }
}
