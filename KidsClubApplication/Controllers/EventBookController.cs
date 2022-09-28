using KidsClubApplication.Data;
using KidsClubApplication.Models;
using Microsoft.AspNetCore.Mvc;
#nullable disable
namespace KidsClubApplication.Controllers
{
    public class EventBookController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public EventBookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        /*public IActionResult EventMessage(Booked b)
        {
            b.CreatedAt = DateTime.Now;
            _context.Booked.Add(b);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                ViewData["ebm"] = $"Something went wrong.";
            }
            finally
            {
                ViewData["ebm"] = $"A message from {b.EFullName}, {b.PNumber}, {b.ESubject}, {b.EMessage} was successful!";

            }

            return View();*/
        public IActionResult EventMessage(Booked b)
        {
            b.CreatedAt = DateTime.Now;
            _context.Booked.Add(b);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                ViewData["ebm"] = $"Something went wrong.";
            }
            finally
            {
                ViewData["ebm"] = $"A message from {b.EFullName}, {b.PNumber}, {b.ESubject}, {b.EMessage} was successful!";

            }

            return View();

        }
    }
}