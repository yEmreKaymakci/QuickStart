using System.ComponentModel.DataAnnotations;

namespace QuickStart.WebUI.Dtos.Messages
{
    public class UpdateMessagesDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim zorunludur.")]
        [MaxLength(100, ErrorMessage = "İsim en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [MaxLength(150, ErrorMessage = "E-posta en fazla 150 karakter olabilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu zorunludur.")]
        [MaxLength(200, ErrorMessage = "Konu en fazla 200 karakter olabilir.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj içeriği zorunludur.")]
        [MaxLength(2000, ErrorMessage = "Mesaj içeriği en fazla 2000 karakter olabilir.")]
        public string Content { get; set; }
    }
}
