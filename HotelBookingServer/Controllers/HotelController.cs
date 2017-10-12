using HotelBookingServer.Models;
using HotelEngineServiceReference;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using HotelBookingServer.Services;
using System;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class HotelController : Controller
    {
        private AppSettings _appSettings;
        private HotelService _hotelService;
        private SingleAvailService _singleAvail;

        public HotelController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _hotelService = new HotelService(_appSettings);
            _singleAvail = new SingleAvailService();
        }

        [HttpGet("multi/{sessionId}")]
        public HotelSearchRS GetMultiAvailDetails(string sessionId)
        {
            return _hotelService.GetMultiAvailDetails(sessionId);
        }

        [HttpGet("single/{hotelId}")]
        public HotelRoomAvailRS Get(int hotelId)
        {
            return _singleAvail.GetHotel(hotelId);
        }
    }
}
