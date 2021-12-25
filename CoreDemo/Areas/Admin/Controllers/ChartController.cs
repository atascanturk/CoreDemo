using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<Category> list = new List<Category> {
                new Category { Name = "Teknoloji", Count = 10 },
                new Category { Name = "Yazılım", Count = 19 } 
            };
                           
            return Json(new {jsonlist = list });
        }
    }
}
