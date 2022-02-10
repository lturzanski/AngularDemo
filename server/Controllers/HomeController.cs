using System;
using Microsoft.AspNetCore.Mvc;

namespace AngularDemo.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
