using HotelEngineServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Implementations
{
    public static class HotelMultiAvailCache
    {
        private static Dictionary<string, Tuple<HotelSearchRQ, HotelSearchRS>> _cache { get; set; } = new Dictionary<string, Tuple<HotelSearchRQ, HotelSearchRS>>();

        public static void AddToCache(HotelSearchRQ hotelSearchRQ, HotelSearchRS hotelSearchRS)
        {
            _cache.Add(hotelSearchRQ.SessionId, new Tuple<HotelSearchRQ, HotelSearchRS>(hotelSearchRQ, hotelSearchRS));
        }

        public static Tuple<HotelSearchRQ, HotelSearchRS> GetFromCache(string sessionId)
        {
            return _cache[sessionId];
        }
    }
}
