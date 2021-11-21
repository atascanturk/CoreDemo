using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard :ViewComponent
    {
        IWriterService _writerService;

        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writer = _writerService.Get(x => x.Mail == usermail);
            return View(writer);
        }
    }
}
