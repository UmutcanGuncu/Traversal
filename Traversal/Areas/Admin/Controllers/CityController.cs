using BusinnesLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CityList()
        {
            var destination= _destinationService.TGetList();
            var jsonCity = JsonConvert.SerializeObject(destination);
            return Json(jsonCity);
        }
        

       
    }
}
