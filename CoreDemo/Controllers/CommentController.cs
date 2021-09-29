using BusinessLayer.Abstract;
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

        public PartialViewResult CommentAddPartial()
        {
            
            return PartialView();
        }
    }
}
