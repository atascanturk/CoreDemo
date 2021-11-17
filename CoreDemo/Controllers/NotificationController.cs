using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        INotificationService _notificationService;

        public NotificationController(INotificationService notificationService )
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AllNotification()
        {
           var notifications =  _notificationService.GetAll();
            return View(notifications);
        }
    }
}
