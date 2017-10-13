using HotelBookingServer.Implementations;
using TripEngineServiceReference;
using hotel = HotelEngineServiceReference;

namespace HotelBookingServer.Services
{
    public class HotelPriceService
    {
        public TripProductPriceRS GetPrice(string sessionId, string roomId)
        {
            var hotelRoomAvailTuple = HotelRoomAvailRQRSCache.GetFromCache(sessionId);
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            Room selectedRoom = new Room();
            foreach (var room in hotelRoomAvailTuple.Item2.Itinerary.Rooms)
            {
                if (room.RoomId.ToString() == roomId)
                {
                    selectedRoom = ReferenceConverter.Convert<hotel.Room, Room>(room);
                    break;
                }
            }
            hotelRoomAvailTuple.Item2.Itinerary.Rooms = ReferenceConverter.Convert<Room[], hotel.Room[]>(new Room[] { selectedRoom });
            TripProductPriceRQ priceRequest = new TripProductPriceRQ()
            {
                TripProduct = new HotelTripProduct()
                {
                    HotelItinerary = ReferenceConverter.Convert<hotel.HotelItinerary, HotelItinerary>(hotelRoomAvailTuple.Item2.Itinerary),
                    HotelSearchCriterion = ReferenceConverter.Convert<hotel.HotelSearchCriterion, HotelSearchCriterion>(hotelRoomAvailTuple.Item1.HotelSearchCriterion),
                },
                //AdditionalInfo = HotelMultiAvailCache.GetFromCache(sessionId).Item1.AdditionalInfo,
                ResultRequested = ResponseType.Unknown,
                SessionId = sessionId,
            };
            TripProductPriceRS priceResponse = tripsEngineClient.PriceTripProductAsync(priceRequest).GetAwaiter().GetResult();
            return priceResponse;
        }
    }
}
