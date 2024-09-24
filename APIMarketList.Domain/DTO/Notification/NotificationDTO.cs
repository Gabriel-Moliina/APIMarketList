namespace APIMarketList.Domain.DTO.Notification
{
    public class NotificationDTO
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public NotificationDTO(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
