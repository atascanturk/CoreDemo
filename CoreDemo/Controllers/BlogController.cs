using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(blogs);
        }

        public IActionResult BlogReadAll(int id)
        {
            Blog blog = _blogService.GetAll(x => x.Id == id).FirstOrDefault();
            return View(blog);
        }

        [AllowAnonymous]
        public IActionResult Test()
        {            
            return View();
        }
        [AllowAnonymous]
        public IActionResult BlogListByWriter()
        {
            var blogs = _blogService.GetAll(x => x.WriterId == 33);
            return View(blogs);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString(),

                                               }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult results = validationRules.Validate(blog);
            if (results.IsValid)
            {
                blog.Status = true;
                blog.CreatedDate = DateTime.Now;
                blog.WriterId = 33;
                _blogService.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
                
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
