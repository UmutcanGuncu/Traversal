using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="Şifrenizi Giriniz")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Şifrenizi Giriniz")]
        [Compare("NewPassword",ErrorMessage ="Şifreler Birbiri İle Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
