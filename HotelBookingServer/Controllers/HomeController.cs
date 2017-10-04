using Microsoft.AspNetCore.Mvc;

namespace HotelBookingServer.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View("Views/Index.cshtml");
        }
    }
}
