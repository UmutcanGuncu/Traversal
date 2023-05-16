using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DashboardController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewBag.Image = user.ImageUrl;
            ViewBag.User = user.Name +" "+ user.Surname;
            

            return View();
        }
        public async Task<IActionResult> MemberDashboard()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Image = user.ImageUrl;
            ViewBag.User = user.Name + " " + user.Surname;
            return View();

        }
    }
}
