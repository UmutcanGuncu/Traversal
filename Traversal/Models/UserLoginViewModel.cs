using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adınızı Giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}
