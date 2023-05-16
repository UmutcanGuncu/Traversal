using BusinnesLayer.Abstract;
using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entityies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            return RedirectToAction("Index","Destination","Admin");
        }
        
        public IActionResult DeleteDestination(int id)
        {
            var destination = _destinationService.TGetById(id);
            _destinationService.TDelete(destination);
            return RedirectToAction("Index", "Destination","Admin");
        }
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var destination = _destinationService.TGetById(id);
            return View(destination);

        }
        [HttpPost]
        public IActionResult EditDestination(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return RedirectToAction("Index", "Destination","Admin");
        }
    }
}
