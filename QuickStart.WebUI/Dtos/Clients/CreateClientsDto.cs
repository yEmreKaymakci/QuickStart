using System.ComponentModel.DataAnnotations;

namespace QuickStart.WebUI.Dtos.Clients
{
    public class CreateClientsDto
    {
        [Required(ErrorMessage = "Görsel URL zorunludur.")]
        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        public string ImageUrl { get; set; }
    }
}
