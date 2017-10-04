using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace HotelBookingServer.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return File(new FileStream("wwwroot/WebPages/index.html", FileMode.Open), "text/html");
        }
    }
}
