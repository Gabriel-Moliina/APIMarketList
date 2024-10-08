using APIMarketList.Application.Interface.Base;
using APIMarketList.Domain.Interface.Entities;
using APIMarketList.Domain.Interface.Notification;
using AutoMapper;

namespace APIMarketList.Application.Application.Base
{
    public class BaseApplication : IBaseApplication
    {
        protected readonly IMapper _mapper;
        protected readonly INotification _notification;
        public BaseApplication(IMapper mapper,
            INotification notification)
        {                      
            _mapper = mapper;
            _notification = notification;
        }
    }
}
