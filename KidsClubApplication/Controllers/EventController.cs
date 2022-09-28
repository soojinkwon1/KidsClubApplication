using Microsoft.AspNetCore.Mvc;

namespace KidsClubApplication.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
