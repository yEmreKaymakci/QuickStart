using System.Text.Json.Serialization;
using QuickStart.WepApi.Entity.Common;

namespace QuickStart.WepApi.Entity
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

        public string Email { get; set; }

        public int NotificationTypeId { get; set; }

        [JsonIgnore]
        public NotificationType? NotificationType { get; set; }
    }
}