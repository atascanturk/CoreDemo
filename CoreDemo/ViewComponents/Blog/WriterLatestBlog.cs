using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class WriterLatestBlog:ViewComponent
    {
        IBlogService _blogService;

        public WriterLatestBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetAll(x => x.WriterId == 1).OrderByDescending(x=>x.Id).Take(3).ToList();
            return View(values);
        }
    }
}
