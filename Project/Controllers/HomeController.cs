using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View("~/Views/Home/Home.cshtml");
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        [Route ("About-us")]
        public IActionResult about()
        {
            return View("Views/about-us.cshtml");
        }
        
        [Route("Contact-us")]
        public IActionResult contact()
        {
            return View("Views/faqs.cshtml");
        }

        [Route("Faqs")]
        public IActionResult faqs()
        {
            return View("Views/contact-us.cshtml");
        }

        [Route("Blog")]
        public IActionResult blog()
        {
            return View("Views/blog.cshtml");
        }

        [Route("CyberSecurity")]
        public IActionResult cyberSecurity()
        {
            return View("Views/cyberSecurity.cshtml");
        }


    }
}
