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
        private Dictionary<string, string> _cache = new Dictionary<string, string>();

        public void AddToCache(string searchTerm, string searchAutosuggestObject)
        {
            _cache[searchTerm] = searchAutosuggestObject;
        }

        public bool Contains(string searchTerm)
        {
            return _cache.ContainsKey(searchTerm);
        }

        public string GetFromCache(string searchTerm)
        {
            return _cache[searchTerm];
        }
    }
}
