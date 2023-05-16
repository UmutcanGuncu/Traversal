using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Entityies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager manager = new DestinationManager(new EFDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values=manager.TGetList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.Id = id;
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserId = userInfo.Id;
            var values=manager.TGetDestinationsWithGuide(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Detail(Destination destination)
        {
            return View();
        }
    }
}
