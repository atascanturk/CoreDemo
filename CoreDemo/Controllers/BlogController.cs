using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
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
    
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;
        IWriterService _writerService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IWriterService writerService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _writerService = writerService;
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
       
        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var blogs = _blogService.GetAll(x => x.Writer.Mail == usermail);
            return View(blogs);
        }

        
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

        
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult results = validationRules.Validate(blog);
            if (results.IsValid)
            {
                var usermail = User.Identity.Name;
                var writer = _writerService.Get(x => x.Mail == usermail);
                blog.Status = true;
                blog.CreatedDate = DateTime.Now;
                blog.WriterId = writer.Id;
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
       
        public IActionResult Delete(int id)
        {
            var blog = _blogService.Get(x => x.Id == id);
            _blogService.Delete(blog);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString(),

                                               }).ToList();
            ViewBag.Categories = categories;

            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem {Text = "Aktif" , Value = "1"},
                new SelectListItem {Text = "Pasif" , Value = "0"}

            };

            ViewBag.Status = status;


            ViewBag.Categories = categories;
           
            var blog = _blogService.Get(x => x.Id == id);

            BlogStatusUpdateViewModel blogStatusUpdateView = new BlogStatusUpdateViewModel();
            blogStatusUpdateView.Blog = blog;

            return View(blogStatusUpdateView);
        }

        [HttpPost]
        public IActionResult Update(BlogStatusUpdateViewModel blogStatusUpdateViewModel)
        {
            blogStatusUpdateViewModel.Blog.Status = Convert.ToBoolean(blogStatusUpdateViewModel.SelectedStatus);
            Blog blog = new Blog();
            blog = blogStatusUpdateViewModel.Blog;
            _blogService.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
