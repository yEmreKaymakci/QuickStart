using System.ComponentModel.DataAnnotations;

namespace QuickStart.WebUI.Dtos.FAQs
{
    public class UpdateFAQsDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [MaxLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }
    }
}
