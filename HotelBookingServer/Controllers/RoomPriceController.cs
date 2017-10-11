using HotelBookingServer.Services;
using HotelEngineServiceReference;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("get")]
        public HotelRoomPriceRS GetPrice()
        {
            return _hotelPriceService.GetPrice();
        }
    }
}
