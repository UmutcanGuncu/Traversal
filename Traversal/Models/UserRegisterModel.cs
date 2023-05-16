
using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
	public class UserRegisterModel
	{
		[Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Lütfen E Posta Adresinizi Giriniz")]
		public string Email { get; set; }
		
		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		[Compare("Password", ErrorMessage ="Şifreler Birbiri İle Eşleşmiyor")] //Karşılaştırma
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
		public string Username { get; set; }
	}
}
