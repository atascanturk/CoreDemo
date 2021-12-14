using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics2:ViewComponent
    {
        IBlogService _blogService;

        public Statistics2(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            @ViewBag.LatestBlog = _blogService.GetAll().LastOrDefault().Title;
            return View();
        }
    }
}
