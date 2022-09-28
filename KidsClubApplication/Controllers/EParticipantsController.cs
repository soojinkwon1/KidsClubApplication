using Microsoft.AspNetCore.Mvc;

namespace KidsClubApplication.Controllers
{
    public class EParticipantsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
