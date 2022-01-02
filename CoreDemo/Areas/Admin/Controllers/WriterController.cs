using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {

        IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetWriterById(int Id)
        {
            var writer = _writerService.Get(x => x.Id == Id);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
            
        }

        public IActionResult WriterList()
        {
            var writers = new List<Writer>();
            writers.Add(new Writer { Mail = "Test", Name = "Test" });
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
    }
}
