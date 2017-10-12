using HotelEngineServiceReference;
using System;
using System.Collections.Generic;

namespace HotelBookingServer.Implementations
{
    public static class HotelRoomAvailRQRSCache
    {
        private static Dictionary<string, Tuple<HotelRoomAvailRQ, HotelRoomAvailRS>> _cache { get; set; } = new Dictionary<string, Tuple<HotelRoomAvailRQ, HotelRoomAvailRS>>();

        public static void AddToCache(HotelRoomAvailRQ hotelRoomAvailRQ, HotelRoomAvailRS hotelRoomAvailRS)
        {
            if (_cache.ContainsKey(hotelRoomAvailRQ.SessionId)) return;
            _cache[hotelRoomAvailRQ.SessionId] = new Tuple<HotelRoomAvailRQ, HotelRoomAvailRS>(hotelRoomAvailRQ, hotelRoomAvailRS);
        }

        public static Tuple<HotelRoomAvailRQ, HotelRoomAvailRS> GetFromCache(string sessionId)
        {
            return _cache[sessionId];
        }
    }
}
