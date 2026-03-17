using System.ComponentModel.DataAnnotations;

namespace MyBakery.WebUI.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
