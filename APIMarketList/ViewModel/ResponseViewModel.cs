using APIMarketList.Domain.DTO.Notification;
using APIMarketList.Domain.Interface.Notification;

namespace APIMarketList.ViewModel
{
    public class ResponseViewModel<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public IList<NotificationDTO> Messages { get; set; }
        public T? Data { get; set; }

        public ResponseViewModel(INotification notification, T data)
        {
            Success = !notification.HasNotifications;
            Messages = notification.Notifications.ToList();
            Data = data;
        }

        public ResponseViewModel(T Data)
        {
            Success = true;
            this.Data = Data;
        }
        public ResponseViewModel(Exception ex)
        {
            Success = false;
            Error = ex.Message;
        }
    }
}
