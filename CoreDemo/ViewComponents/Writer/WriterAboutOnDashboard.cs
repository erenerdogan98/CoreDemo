﻿using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerService;
        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _writerService.GetWriterByIdAsync(1);
            return View(values);
        }
    }
}
