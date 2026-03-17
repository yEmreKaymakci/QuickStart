using System.ComponentModel.DataAnnotations;

namespace MyBakery.WebUI.Dtos.Testimonials
{
    public class CreateTestimonialDto
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Unvan zorunludur.")]
        [MaxLength(100, ErrorMessage = "Unvan en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [MaxLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Puan zorunludur.")]
        [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
        public int Rate { get; set; }

        [Required(ErrorMessage = "Görsel URL zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        public string ImageUrl { get; set; }
    }
}
