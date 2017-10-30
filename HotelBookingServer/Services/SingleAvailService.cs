using System;
using HotelEngineServiceReference;
using HotelBookingServer.Implementations;

namespace HotelBookingServer.Services
{
    public class SingleAvailService
    {
        public HotelRoomAvailRS GetHotel(string sessionId, int hotelId)
        {
            HotelRoomAvailRQ hotelRoomAvailRQ = new HotelRoomAvailRQ()
            {
                ResultRequested = ResponseType.Complete,
                SessionId = sessionId,
                HotelSearchCriterion = HotelMultiAvailCache.GetFromCache(sessionId).Item1.HotelSearchCriterion,
                Itinerary = new HotelItinerary()
                {
                    Id = Guid.Parse(sessionId),
                    ItineraryStatus = ItineraryStatusType.Unbooked,
                    Rph = 0,
                    AllPaxDetailsRequired = false,
                    GuaranteeRequired = false,
                    HotelProperty = new HotelProperty()
                    {
                        Id = hotelId
                    },
                    ShippingAddressRequired = false
                }
            };
            HotelEngineClient hotelEngineClient = new HotelEngineClient();
            var hotelRoomAvailRS = hotelEngineClient.HotelRoomAvailAsync(hotelRoomAvailRQ).GetAwaiter().GetResult();
            HotelRoomAvailRQRSCache.AddToCache(hotelRoomAvailRQ, hotelRoomAvailRS);
            return hotelRoomAvailRS;
        }
    }
}
