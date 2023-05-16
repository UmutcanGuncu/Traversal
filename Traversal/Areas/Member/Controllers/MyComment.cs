﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class MyComment : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
