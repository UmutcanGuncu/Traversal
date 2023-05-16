using BusinnesLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;

namespace Traversal.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IContactUsService _contactUsService;
        public ContactController(IContactService contactService, IContactUsService contactUsService)
        {
            _contactService = contactService;
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _contactService.TGetList();
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(ContactUs contactUs)
        {
            contactUs.Date = DateTime.Now;
            _contactUsService.TAdd(contactUs);
            return RedirectToAction("Index", "Default");
        }
    }
}
