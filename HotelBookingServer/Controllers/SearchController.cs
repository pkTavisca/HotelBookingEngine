using Microsoft.AspNetCore.Mvc;
using HotelBookingServer.Models;
using HotelBookingServer.Services;
using Microsoft.Extensions.Options;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class SearchController : Controller
    {
        private SearchService _searchService;

        public SearchController(IOptions<AppSettings> appSettings)
        {
            _searchService = new SearchService(appSettings);
        }

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

        [HttpGet("getResults/{searchId}")]
        public object GetResultsFromSearch(string searchId)
        {
            return _searchService.GetAutoSuggestResults(searchId);
        }
    }
}
