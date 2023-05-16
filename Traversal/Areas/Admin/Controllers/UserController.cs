using BusinnesLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ICommentService _commentService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, ICommentService commentService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _commentService = commentService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            
            var values=_appUserService.TGetList();
            return View(values);
            
        }
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user= _appUserService.TGetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index","User","Admin");
        }
        //Buraları hallet
        public IActionResult CommentUser(int id)
        {
            
            return View();

        }
        public IActionResult ReservationUser(int id)
        {
            
            var values=_reservationService.GetListWithAppUserId(id);
            return View(values);
        }
    }
}
