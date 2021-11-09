using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification :ViewComponent
    {
        IMessageService _messageService;

        public WriterMessageNotification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            string receiver = "atascanturk@gmail.com";
            var messages = _messageService.GetAll(x => x.Receiver == receiver);
            return View(messages);
        }
    }
}
