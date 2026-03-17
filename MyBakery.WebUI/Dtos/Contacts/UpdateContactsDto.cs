using System.ComponentModel.DataAnnotations;

namespace MyBakery.WebUI.Dtos.Contacts
{
    public class UpdateContactsDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adres zorunludur.")]
        [MaxLength(300, ErrorMessage = "Adres en fazla 300 karakter olabilir.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [MaxLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [MaxLength(150, ErrorMessage = "E-posta en fazla 150 karakter olabilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Harita URL zorunludur.")]
        public string MapUrl { get; set; }
    }
}
