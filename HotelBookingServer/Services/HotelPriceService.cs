using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelEngineServiceReference;

namespace HotelBookingServer.Services
{
    public class HotelPriceService
    {
        public HotelRoomPriceRS GetPrice()
        {
            HotelEngineClient hotelEngineClient = new HotelEngineClient();
            HotelRoomPriceRQ priceRequest = new HotelRoomPriceRQ()
            {
                AdditionalInfo = new StateBag[] { },
                HotelSearchCriterion = new HotelSearchCriterion() { },
                Itinerary = new HotelItinerary() { },
                ResultRequested = ResponseType.Complete,
                SessionId = ""
            };
            HotelRoomPriceRS priceResponse = hotelEngineClient.HotelRoomPriceAsync(priceRequest).GetAwaiter().GetResult();
            return priceResponse;
        }
    }
}
