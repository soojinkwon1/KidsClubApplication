﻿using Microsoft.AspNetCore.Mvc;

namespace KidsClubApplication.Controllers
{
    public class SubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string SubscribeMessage(string email)
        {

            return $"A subscribe from  {email}";
        }
    }
}