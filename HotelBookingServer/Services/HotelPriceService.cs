using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelEngineServiceReference;
using HotelBookingServer.Implementations;

namespace HotelBookingServer.Services
{
    public class HotelPriceService
    {
        public HotelRoomPriceRS GetPrice(string sessionId)
        {
            var hotelRoomAvailTuple = HotelRoomAvailRQRSCache.GetFromCache(sessionId);
            HotelEngineClient hotelEngineClient = new HotelEngineClient();
            HotelRoomPriceRQ priceRequest = new HotelRoomPriceRQ()
            {
                AdditionalInfo = HotelMultiAvailCache.GetFromCache(sessionId).Item1.AdditionalInfo,
                HotelSearchCriterion = hotelRoomAvailTuple.Item1.HotelSearchCriterion,
                Itinerary = hotelRoomAvailTuple.Item2.Itinerary,
                ResultRequested = ResponseType.Complete,
                SessionId = sessionId
            };
            HotelRoomPriceRS priceResponse = hotelEngineClient.HotelRoomPriceAsync(priceRequest).GetAwaiter().GetResult();
            return priceResponse;
        }
    }
}
