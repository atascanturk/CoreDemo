using BusinessLayer.Abstract;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class NewsController : Controller
    {
        INewsService _newsService;
        IBlogService _blogService;

        public NewsController(INewsService newsService, IBlogService blogService)
        {
            _newsService = newsService;
            _blogService = blogService;
        }
       

        [HttpGet]
        public PartialViewResult Subscribe()
        {
            return PartialView();
        }
        

        [HttpPost]
        public IActionResult SubscribeMail(SubscribeViewModel subscribeViewModel)
        {
            News news = new News
            {
                Mail = subscribeViewModel.Mail,
                MailStatus = true
            };
            _newsService.Add(news);
            var blog = _blogService.Get(x => x.Id == subscribeViewModel.Id);

            return RedirectToAction("BlogReadAll","Blog", blog);
            
        }

      
    }
}
