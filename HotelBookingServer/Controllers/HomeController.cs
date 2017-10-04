using Microsoft.AspNetCore.Mvc;

namespace HotelBookingServer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
