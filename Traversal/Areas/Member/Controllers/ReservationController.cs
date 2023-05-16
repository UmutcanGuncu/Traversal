using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]

    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyActiveReservation() //Aktif
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = reservationManager.GetListWithReservationByAccepted(user.Id);
            return View(valueList);
        }
        public async Task<IActionResult> MyPassiveReservation() //Pasif
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList=reservationManager.GetListWithReservationByPrevious(user.Id);
            return View(valueList);
        }
        public async Task<IActionResult> MyApprovalReservation() //Onay Bekleyen
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = reservationManager.GetListWithReservationByWaitApproval(values.Id);
            return View(valueList);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.Value = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation reservation)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = user.Id;
            reservation.Status = "Onay Bekliyor";
            reservationManager.TAdd(reservation);
            return RedirectToAction("MyActiveReservation");
        }
        public IActionResult Deneme()
        {
            return View();

        }
    }
}
