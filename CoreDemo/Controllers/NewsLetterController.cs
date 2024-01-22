﻿using BLL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterService;
        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService ?? throw new ArgumentNullException(nameof(_newsLetterService));
        }
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newsLetterService.AddAsync(newsLetter);
            return PartialView();
        }
    }
}