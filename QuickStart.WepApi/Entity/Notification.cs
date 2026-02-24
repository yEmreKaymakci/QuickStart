namespace QuickStart.WepApi.Entity
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }
    }
}
//1 Numaralı sipariş alındı. Bildirim Türü: sipariş 
//Akşam 11 de site güncellenecek. Bildirim Türü: Güncelleme 
//2 numaralı süpariş alındı. Bildirim Türü: Sipariş 