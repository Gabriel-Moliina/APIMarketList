using APIMarketList.Domain.DTO.Notification;
using APIMarketList.Domain.Interface.Notification;

namespace APIMarketList.ViewModel
{
    public class ResponseVoidViewModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public IList<NotificationDTO> Messages { get; set; }

        public ResponseVoidViewModel(INotification notification)
        {
            Success = !notification.HasNotifications;
            Messages = notification.Notifications.ToList();
        }
        public ResponseVoidViewModel(Exception ex)
        {
            Success = false;
            Error = ex.Message;
        }
    }
}
