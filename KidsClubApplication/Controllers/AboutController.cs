using KidsClubApplication.Models;
using Microsoft.AspNetCore.Mvc;
using KidsClubApplication.Data;

#nullable disable

namespace KidsClubApplication.Controllers
{

    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AboutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubscribeMessage(SuMessage s)
        {
            s.CreatedAt = DateTime.Now;
            _context.SuMessage.Add(s);
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
                ViewData["sub"] = $"A message to {s.Email} has been sent successful.";

            }

            return View();

        }
    }
}