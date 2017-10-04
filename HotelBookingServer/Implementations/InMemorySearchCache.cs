using HotelBookingServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingServer.Models;

namespace HotelBookingServer.Implementations
{
    public class InMemorySearchCache : ISearchCache
    {
        private Dictionary<string, SearchObject> _searches = new Dictionary<string, SearchObject>();

        public string AddToCache(SearchObject searchObject)
        {
            string guid = Guid.NewGuid().ToString();
            _searches.Add(guid, searchObject);
            return guid;
        }

        public SearchObject GetFromCache(string searchId)
        {
            return _searches[searchId];
        }
    }
}
