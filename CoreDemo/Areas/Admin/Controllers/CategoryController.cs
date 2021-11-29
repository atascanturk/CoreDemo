using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int page=1)
        {
            var categories = _categoryService.GetAll().ToPagedList(page,3);
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(category);
            if (results.IsValid)
            {
                category.Status = true;
                _categoryService.Add(category);
                return RedirectToAction("Index", "Category");

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
            var blog = _categoryService.Get(x => x.Id == id);
            _categoryService.Delete(blog);
            return RedirectToAction("Index");
        }
    }
}
