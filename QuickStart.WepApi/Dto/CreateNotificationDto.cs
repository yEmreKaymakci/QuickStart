namespace QuickStart.WepApi.Dto
{
    public class CreateNotificationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public string Email { get; set; }
        public string NotificationTypeName { get; set; }
    }
}
