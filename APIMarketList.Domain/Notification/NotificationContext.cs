using APIMarketList.Domain.DTO.Notification;
using APIMarketList.Domain.Interface.Notification;
using FluentValidation.Results;

namespace APIMarketList.Domain.Notification
{
    public class NotificationContext : INotification
    {
        private readonly List<NotificationDTO> _notifications;
        public IReadOnlyCollection<NotificationDTO> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();
        public NotificationContext()
        {
            _notifications = new List<NotificationDTO>();
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new NotificationDTO(key, message));
        }

        public void AddNotification(NotificationDTO item)
        {
            _notifications.Add(item);
        }

        public void AddNotification(ValidationResult validationResult)
        {
            _notifications.AddRange(validationResult.Errors.Select(error => new NotificationDTO(error.PropertyName, error.ErrorMessage)));
        }
    }
}
