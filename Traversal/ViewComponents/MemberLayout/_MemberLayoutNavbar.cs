
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Traversal.Models;

namespace Traversal.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            UserInformationsViewModel model = new UserInformationsViewModel()
            {
                
                Name = user.Name,
               
                ImageUrl= user.ImageUrl
            };
            return View(model);
        }

    }
}
