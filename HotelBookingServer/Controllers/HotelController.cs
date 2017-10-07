using HotelBookingServer.Models;
using HotelEngineServiceReference;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using HotelBookingServer.Services;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class HotelController : Controller
    {
        private AppSettings _appSettings;
        private HotelService _hotelService;

        public HotelController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _hotelService = new HotelService(_appSettings);
        }

        [HttpGet("get")]
        public HotelSearchRS GetHotelDetails()
        {
            return _hotelService.GetHotelDetails();
        }
    }
}
