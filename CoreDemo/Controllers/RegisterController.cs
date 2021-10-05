using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{   
    public class RegisterController : Controller
    {
        IWriterService _writerService;
        ICityService _cityService;

        public RegisterController(IWriterService writerService, ICityService cityService)
        {
            _writerService = writerService;
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cities = _cityService.GetAll();
            List<SelectListItem> cityValues = (from x in cities
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString(),

                                                   }).ToList();
            ViewBag.Cities = cityValues;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid) { 
            writer.Status = true;
            writer.About = String.Empty;
            _writerService.Add(writer);
                return RedirectToAction("Index", "Blog");
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
