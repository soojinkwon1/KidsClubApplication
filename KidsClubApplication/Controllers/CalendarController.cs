using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KidsClubApplication.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Calendar = "C";
            int month = DateTime.Now.Month;
            ViewBag.Month = month;
            int year = DateTime.Now.Year;
            ViewBag.Year = year;
            Debug.WriteLine($"Month is {ViewBag.Month}");
            return View();
        }

       /* public IActionResult Index(string id)
        {
            string[] parts = id.Split('-');
            int month = int.Parse(parts[0]);
            int year = int.Parse(parts[1]);

            return View();
        }*/

        /*
        public string echo(string Xmonth)
        {
            //return splitmonth;
             //08/2022
            string[] parts = Xmonth.Split('/');
            int month = int.Parse(parts[0]);
            int year = int.Parse(parts[1]);


        }
        */
    }
}
