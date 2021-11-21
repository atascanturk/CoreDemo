using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [AllowAnonymous]
        public IActionResult Inbox()
        {
            var messages = _messageService.GetAll(x => x.ReceiverId == 33);
            return View(messages);
        }

        [AllowAnonymous]
        public IActionResult Update(int id)
        {

            var message = _messageService.Get(x => x.Id == id);
            return View(message);
        }

    }
}
