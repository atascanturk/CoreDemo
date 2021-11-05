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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        IWriterService _writerService;
        ICityService _cityService;

        public WriterController(IWriterService writerService, ICityService cityService)
        {
            _writerService = writerService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writer = _writerService.Get(x => x.Id == 33);
            return View(writer);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(writer);

            if (results.IsValid)
            {
                writer.Status = true;
                _writerService.Update(writer);                
                return RedirectToAction("Index", "Dashboard");
            }

            else
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
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
        public IActionResult WriterAdd(AddProfileModelView addProfileModelView)
        {
            Writer writer = new Writer();

            if (addProfileModelView.Image != null) // TO DO : Static Helper methoda taşınacak
            {
                var extension = Path.GetExtension(addProfileModelView.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterProfileImage", imageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileModelView.Image.CopyTo(stream);
                writer.Image = imageName;

            }
            writer.Name = addProfileModelView.Name;
            writer.Mail = addProfileModelView.Mail;
            writer.About = addProfileModelView.About;
            writer.Password = addProfileModelView.Password;
            writer.Status = addProfileModelView.Status;
            writer.CityId = addProfileModelView.CityId;
            _writerService.Add(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
