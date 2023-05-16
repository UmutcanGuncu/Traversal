using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Traversal.Models;

namespace Traversal.Controllers
{
	[AllowAnonymous] // kullanıcı her türlü buraya erişim sağlayabilecek bu attribute sayesinde
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		public LoginController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		//kaydolma ve giriş yapma işlemleri bu controllerdan yönetilecek
		[HttpGet]
		public IActionResult SignUp() //Kaydolma
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterModel userRegisterModel)
		{
			AppUser appUser = new AppUser()
			{
				Name = userRegisterModel.Name,
				Surname = userRegisterModel.Surname,
				UserName=userRegisterModel.Username,
				Email = userRegisterModel.Email,
				 //Appuser sınıfına ait nesneye gerekli parametreleri atadık
			};
			if(userRegisterModel.Password ==null)
			{
				return View(userRegisterModel);
			}
			else if (userRegisterModel.Password == userRegisterModel.ConfirmPassword) //şifrelerin eşleşip eşleşmediğine baktık
			{
				
				var result = await _userManager.CreateAsync(appUser, userRegisterModel.Password); //Oluşturduk
				if (result.Succeeded)
				{
					return RedirectToAction("SignIn","Login");//başarılı ise signın sayfasına yönlendirdik
				}
				else
				{
					foreach (var item in result.Errors) //başarısız ise hata mesajlarını döndürdük
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(userRegisterModel);
		}
		[HttpGet]
		public IActionResult SignIn()//Giriş yapma
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(UserLoginViewModel userLoginViewModel)
		{
			if(ModelState.IsValid) 
			{
				var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.Username,userLoginViewModel.Password,false,true);
				if (result.Succeeded) 
				{
					return RedirectToAction("Index", "Profile", new {area="Member"});
				}
				else
				{
					return RedirectToAction("SignIn","Login");
				}
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Default");
		}
	}
}
