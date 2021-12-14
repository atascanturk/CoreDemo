using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics4 :ViewComponent
    {
        IAdminService _adminService;

        public Statistics4(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Admin = _adminService.Get(x => x.Id == 1).Name;
            ViewBag.AdminImage = _adminService.Get(x => x.Id == 1).ImageUrl;
           
            return View();
        }
    }
}
