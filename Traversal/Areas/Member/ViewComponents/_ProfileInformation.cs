using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal.Areas.Member.ViewComponents
{
    
    public class _ProfileInformation:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = user.Name + " " + user.Surname;
            ViewBag.Telephone = user.PhoneNumber;
            ViewBag.Email = user.Email;
            return View();
        }
    }
}
