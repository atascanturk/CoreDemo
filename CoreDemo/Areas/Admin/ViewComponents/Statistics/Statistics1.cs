using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistics1:ViewComponent
    {
        IBlogService _blogService;
        IContactService _contactService;
        ICommentService _commentService;

        public Statistics1(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
            _contactService = contactService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = _blogService.GetAll().Count;
            ViewBag.MessageCount = _contactService.GetAll().Count;
            ViewBag.CommentCount = _commentService.GetAll().Count;
            return View();
        }
    }
}
