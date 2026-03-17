using System.ComponentModel.DataAnnotations;

namespace QuickStart.WebUI.Dtos.Abouts
{
    public class UpdateAboutsDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [MaxLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "1. Görsel URL zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        public string ImageUrl1 { get; set; }

        [Required(ErrorMessage = "2. Görsel URL zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        public string ImageUrl2 { get; set; }

        [Required(ErrorMessage = "3. Görsel URL zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        public string ImageUrl3 { get; set; }
    }
}
