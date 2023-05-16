using AutoMapper;
using BusinnesLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement
                {
                    Title = model.Title,
                    Content = model.Content,
                    DateTime = DateTime.Now
                });
                return RedirectToAction("Index", "Announcement");
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.TGetById(id);
            _announcementService.TDelete(value);
            return RedirectToAction("Index", "Announcement");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetById(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    Id=model.Id,
                    Title=model.Title,
                    Content=model.Content,
                    DateTime=DateTime.Now
                });
                return RedirectToAction("Index", "Announcement");
            }
            return View(model);
        }
    }
}
