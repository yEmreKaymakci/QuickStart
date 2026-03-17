using System.ComponentModel.DataAnnotations;

namespace QuickStart.WebUI.Dtos.Features
{
    public class UpdateFeaturesDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İkon URL zorunludur.")]
        public string IconUrl { get; set; }

        [Required(ErrorMessage = "Görsel URL zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        public string ImageUrl { get; set; }
    }
}
