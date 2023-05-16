using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Traversal.Areas.Member.Models;

namespace Traversal.Areas.Member.Controllers
{

    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.PhoneNumber = values.PhoneNumber;
            userEditViewModel.Email = values.Email;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditViewModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditViewModel.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEditViewModel.Image.CopyToAsync(stream);
                user.ImageUrl = "/UserImages/"+ imageName;
            }
            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.Surname;
            user.PhoneNumber = userEditViewModel.PhoneNumber;
            if (userEditViewModel.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("SignIn", "Login");

                }

            }
            else
            {
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Default");
                }
            }
            return View();
        }
    }
}
