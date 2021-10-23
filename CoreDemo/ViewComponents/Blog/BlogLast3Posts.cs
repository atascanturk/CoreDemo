using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogLast3Posts : ViewComponent
    {
        IBlogService _blogService;

        public BlogLast3Posts(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetAll().OrderByDescending(x => x.Id).Take(3).ToList();
            return View(values);
        }
    }
}
