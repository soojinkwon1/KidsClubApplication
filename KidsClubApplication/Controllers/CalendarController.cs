using Microsoft.AspNetCore.Mvc;

namespace KidsClubApplication.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
