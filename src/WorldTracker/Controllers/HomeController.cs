using Microsoft.AspNetCore.Mvc;
using System;

namespace WorldTracker.Controllers
{
    public class HomeController : Controller
    {
        // Default page
        public IActionResult Index()
        {
            return View();
        }
    }
}