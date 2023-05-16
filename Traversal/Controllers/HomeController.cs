using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Traversal.Models;

namespace Traversal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index Sayfası Çağrıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Priva Çağrıldı");
            return View();
        }

       
        public IActionResult Error()
        {
            return View();
        }
    }
}
