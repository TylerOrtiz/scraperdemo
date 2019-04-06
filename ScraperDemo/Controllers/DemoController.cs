using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScraperDemo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["BaseUrl"] = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            return View();
        }
    }
}