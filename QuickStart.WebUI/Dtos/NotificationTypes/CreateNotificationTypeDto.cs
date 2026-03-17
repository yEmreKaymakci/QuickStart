using System.ComponentModel.DataAnnotations;

namespace QuickStart.WebUI.Dtos.NotificationTypes
{
    public class CreateNotificationTypeDto
    {
        [Required(ErrorMessage = "Bildirim türü adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Tür adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }
    }
}
