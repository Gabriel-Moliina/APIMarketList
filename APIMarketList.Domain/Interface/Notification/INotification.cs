using APIMarketList.Domain.DTO.Notification;
using FluentValidation.Results;

namespace APIMarketList.Domain.Interface.Notification
{
    public interface INotification
    {
        IReadOnlyCollection<NotificationDTO> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);
        void AddNotification(NotificationDTO item);
        void AddNotification(ValidationResult validationResult);
    }
}
