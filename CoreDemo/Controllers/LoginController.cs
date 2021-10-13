using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IWriterService _writerService;

        public LoginController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var triedWriter = _writerService.Get(x => x.Mail == writer.Mail && x.Password==writer.Password);
            
            if (triedWriter == null)
            {
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,writer.Mail)
            };

            var userIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Blog");

        }
    }
}
