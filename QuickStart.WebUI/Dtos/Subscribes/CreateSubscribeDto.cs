using System.ComponentModel.DataAnnotations;

namespace QuickStart.WebUI.Dtos.Subscribes
{
    public class CreateSubscribeDto
    {
        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [MaxLength(150, ErrorMessage = "E-posta en fazla 150 karakter olabilir.")]
        public string Email { get; set; }
    }
}
