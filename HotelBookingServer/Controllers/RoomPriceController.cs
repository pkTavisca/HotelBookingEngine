using HotelBookingServer.Models;
using HotelBookingServer.Services;
using HotelEngineServiceReference;
using Microsoft.AspNetCore.Mvc;
using TripEngineServiceReference;

namespace HotelBookingServer.Controllers
{
    [Route("/api/[controller]")]
    public class RoomPriceController : Controller
    {
        HotelPriceService _hotelPriceService;

        public RoomPriceController()
        {
            _hotelPriceService = new HotelPriceService();
        }

        [HttpGet("get/{sessionId}/{roomId}")]
        public UpdatedPriceResponse GetPrice(string sessionId, string roomId)
        {
            return _hotelPriceService.GetPrice(sessionId, roomId);
        }
    }
}
