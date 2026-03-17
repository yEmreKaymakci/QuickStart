using System.ComponentModel.DataAnnotations;

namespace MyBakery.WebUI.Dtos.FeatureServices
{
    public class CreateFeatureServiceDto
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İkon URL zorunludur.")]
        public string IconUrl { get; set; }
    }
}
