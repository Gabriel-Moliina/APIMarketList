using APIMarketList.Application.Application.Base;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.Notification;
using AutoMapper;

namespace APIMarketList.Application.Application
{
    public class AuthApplication : BaseApplication, IAuthApplication
    {
        public AuthApplication(IMapper mapper, INotification notification) : base(mapper, notification)
        {

        }
    }
}
