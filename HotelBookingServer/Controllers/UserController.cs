using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingServer.Controllers
{
    [Route("/")]
    public class UserController : Controller
    {
        [HttpGet("signUp")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
