using HotelBookingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Implementations
{
    //TODO: Enable cache data removal
    public static class SearchDataCache
    {
        private static Dictionary<string, SearchObject> _cache = new Dictionary<string, SearchObject>();

        public static SearchObject GetFromCache(string sessionId)
        {
            return _cache[sessionId];
        }

        public static void AddToCache(string sessionId, SearchObject searchObject)
        {
            _cache[sessionId] = searchObject;
        }
    }
}
