using System.ComponentModel.DataAnnotations;

namespace MyBakery.WebUI.Dtos.Notification
{
    public class CreateNotificationWithNotificationTypeDto
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik zorunludur.")]
        [MaxLength(1000, ErrorMessage = "İçerik en fazla 1000 karakter olabilir.")]
        public string Content { get; set; }

        public bool IsRead { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [MaxLength(150, ErrorMessage = "E-posta en fazla 150 karakter olabilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bildirim türü zorunludur.")]
        public string NotificationTypeName { get; set; }
    }
}
