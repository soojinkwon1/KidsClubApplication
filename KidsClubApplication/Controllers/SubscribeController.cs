using KidsClubApplication.Data;
using KidsClubApplication.Models;
using Microsoft.AspNetCore.Mvc;
#nullable disable


namespace KidsClubApplication.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubscribeMessage(string email)
        {
            Subscribe subscribe1 = new Subscribe();
            subscribe1.Email = email;
            subscribe1.CreatedAt = DateTime.Now;/*
            _context.Message.Add(subscribe1);*/
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                ViewData["sub"] = $"Some thing went wrong.{ex.Message}";
            }
            finally
            {
                ViewData["sub"] = $"subscribe {email} has been successful.";

            }

            return View();

        }
    }
}