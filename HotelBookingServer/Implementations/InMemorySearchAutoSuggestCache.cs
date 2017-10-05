using HotelBookingServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingServer.Models;

namespace HotelBookingServer.Implementations
{
    public class InMemorySearchAutoSuggestCache : ISearchAutoSuggestCache
    {
        private Dictionary<string, SearchAutosuggestObject> _cache = new Dictionary<string, SearchAutosuggestObject>();

        public void AddToCache(string id, SearchAutosuggestObject searchAutosuggestObject)
        {
            _cache[id] = searchAutosuggestObject;
        }

        public SearchAutosuggestObject GetFromCache(string id)
        {
            return _cache[id];
        }
    }
}
