using KidsClubApplication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace KidsClubApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Messages
        [Authorize(Roles = "Administrator")]
        public IActionResult Messages()
        {
            return View(_context.Message.OrderByDescending(x => x.Id).ToList());
        }

        // GET: Admin/Subscribe
        [Authorize(Roles = "Administrator")]
        public IActionResult SuMessages()
        {
            return View(_context.SuMessage.OrderByDescending(x => x.Id).ToList());
        }

        // GET: Admin/Booked
        [Authorize(Roles = "Administrator")]
        public IActionResult BookedMessage()
        {
            return View(_context.Booked.OrderByDescending(x => x.Id).ToList());
        }

    }
}