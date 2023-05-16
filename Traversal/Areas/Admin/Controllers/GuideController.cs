using BusinnesLayer.Abstract;
using EntityLayer.Entityies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.IO;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values=_guideService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(AddGuideViewModel addGuideViewModel)
        {
            Guide guide= new Guide();
            if(addGuideViewModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(addGuideViewModel.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                addGuideViewModel.Image.CopyTo(stream);
                guide.Image= "/UserImages/" + imageName;
                stream.Close();
            }
            guide.Description = addGuideViewModel.Description;
            guide.Status = true;
            guide.Name = addGuideViewModel.Name;
            guide.TwitterUrl = addGuideViewModel.TwitterUrl;
            guide.InstagramUrl = addGuideViewModel.InstagramUrl;
            _guideService.TAdd(guide);
            return RedirectToAction("Index","Guide");
        }
        [HttpGet]
        public IActionResult EditGuide(int id) 
        {
            var value = _guideService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
        
            _guideService.TUpdate(guide);
            return RedirectToAction("Index","Guide");
        }
    }
}
