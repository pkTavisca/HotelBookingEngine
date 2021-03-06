﻿using HotelBookingServer.Services;
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

        [HttpGet("hotelListing/{searchGuid}")]
        public IActionResult GetHotelListingPage(string searchGuid)
        {
            return File(new FileStream("wwwroot/WebPages/hotel-listing.html", FileMode.Open), "text/html");
        }

        [HttpGet("HotelDetails/{hotelId}")]
        public IActionResult GetHotelDetailsPage(string hotelId)
        {
            return File(new FileStream("wwwroot/WebPages/hotel-details.html", FileMode.Open), "text/html");
        }
    }
}
