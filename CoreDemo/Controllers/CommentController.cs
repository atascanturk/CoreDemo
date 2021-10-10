using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {

        ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult CommentPartial(int id)
        {
            var comments = _commentService.GetAll(x => x.BlogId == id);
            return PartialView(comments);
        }

        [HttpGet]
        public PartialViewResult CommentAddPartial()
        {
            
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult CommentAddPartial(Comment comment)
        {
            comment.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.Status = true;
            comment.BlogId = 2;
            _commentService.Add(comment);
            return PartialView();
        }
    }
}
