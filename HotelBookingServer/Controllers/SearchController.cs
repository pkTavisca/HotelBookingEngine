using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class SearchController : Controller
    {
        [HttpPost("new")]
        public string OnNewSearch()
        {
            return "some id";
        }
    }
}
