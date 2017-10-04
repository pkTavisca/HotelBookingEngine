using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelBookingServer.Models;
using HotelBookingServer.Contracts;
using HotelBookingServer.Generators;
using HotelBookingServer.Constants;
using HotelBookingServer.Services;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class SearchController : Controller
    {
        private SearchService _searchService = new SearchService();

        [HttpPost("new")]
        public string OnNewSearch([FromBody]SearchObject searchObject)
        {
            return _searchService.OnNewSearch(searchObject);
        }

        [HttpGet("get/{searchId}")]
        public SearchObject GetSearchObject(string searchId)
        {
            return _searchService.GetSearchObject(searchId);
        }
    }
}
