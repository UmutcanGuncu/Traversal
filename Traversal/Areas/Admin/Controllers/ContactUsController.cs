using BusinnesLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values= _contactUsService.TGetList();
            return View(values);
        }
        public IActionResult Details(int id) 
        {
            var value=_contactUsService.GetListByFilter(id);
            return View(value);
        }
        public IActionResult Delete(int id)
        {
            var comment=_contactUsService.TGetById(id);
            _contactUsService.TDelete(comment);
            return RedirectToAction("Index");
        }
    }
}
