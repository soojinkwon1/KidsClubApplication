using KidsClubApplication.Models;
using Microsoft.AspNetCore.Mvc;
using KidsClubApplication.Data;

#nullable disable

namespace KidsClubApplication.Controllers
{
    
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {
            Message message1 = new Message();
            message1.FullName = fullName;
            message1.Email = email;
            message1.Body = message;
            message1.CreatedAt = DateTime.Now;
            _context.Message.Add(message1);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"Some thing went wrong.{ex.Message}";
            }
            finally
            {
                ViewData["msg"] = $"A message from {fullName}, {email} has been sent successfully. <br /> Message Body: {message}";

            }

            return View();

        }
    }
}