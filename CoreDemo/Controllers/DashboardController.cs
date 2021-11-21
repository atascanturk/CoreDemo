using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        ICategoryService _categoryService;
        IBlogService _blogService;

        public DashboardController(ICategoryService categoryService, IBlogService blogService)
        {
            _categoryService = categoryService;
            _blogService = blogService;
        }

       
        public IActionResult Index()
        {

            var usermail = User.Identity.Name;
            ViewBag.Mail = usermail;
            ViewBag.BlogCount = _blogService.GetAll().Count;
            ViewBag.WriterBlogCount = _blogService.GetAll(x => x.Writer.Mail == usermail).Count;
            ViewBag.CategoryCount = _categoryService.GetAll().Count;

            return View();
        }
    }
}
