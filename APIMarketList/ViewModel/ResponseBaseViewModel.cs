using APIMarketList.Domain.DTO.Notification;
using APIMarketList.Domain.Interface.Notification;

namespace APIMarketList.ViewModel
{
    public class ResponseBaseViewModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public IList<NotificationDTO> Messages { get; set; }

        public ResponseBaseViewModel(INotification notification)
        {
            Success = !notification.HasNotifications;
            Messages = notification.Notifications.ToList();
        }
        public ResponseBaseViewModel(Exception ex)
        {
            Success = false;
            Error = ex.Message;
        }
    }
}
