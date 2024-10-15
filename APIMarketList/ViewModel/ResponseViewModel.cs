using APIMarketList.Domain.DTO.Notification;
using APIMarketList.Domain.Interface.Notification;

namespace APIMarketList.ViewModel
{
    public class ResponseViewModel<T> : ResponseBaseViewModel
    {
        public ResponseViewModel(INotification notification) : base(notification)
        {
        }

        public ResponseViewModel(Exception e) : base(e)
        {
            
        }

        public T? Data { get; private set; }

        public void SetData(T? data)
        {
            Data = data;
        }
    }
}
