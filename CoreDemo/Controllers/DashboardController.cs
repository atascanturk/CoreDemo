using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        ICategoryService _categoryService;
        IBlogService _blogService;

        public DashboardController(ICategoryService categoryService, IBlogService blogService)
        {
            _categoryService = categoryService;
            _blogService = blogService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.BlogCount = _blogService.GetAll().Count;
            ViewBag.WriterBlogCount = _blogService.GetAll(x => x.WriterId == 33).Count;
            ViewBag.CategoryCount = _categoryService.GetAll().Count;

            return View();
        }
    }
}
