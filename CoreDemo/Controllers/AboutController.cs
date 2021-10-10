using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var abouts = _aboutService.GetAll().FirstOrDefault();
            return View(abouts);
        }

        public PartialViewResult SocialMedia()
        {
            return PartialView();
        }
    }
}
