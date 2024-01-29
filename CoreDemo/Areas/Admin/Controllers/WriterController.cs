﻿using CoreDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "Ahmet"
            },
            new WriterClass
            {
                Id = 2,
                Name = "Ayşe"
            },
            new WriterClass
            {
                Id = 3,
                Name = "Mehmet"
            }
        };
    }
}
