using System;
using HotelBookingServer.Constants;
using HotelBookingServer.Contracts;
using HotelBookingServer.Generators;
using HotelBookingServer.Models;

namespace HotelBookingServer.Services
{
    public class SearchService
    {
        private ISearchCache _searchCache = SearchCacheGenerator.Generate(CacheType.InMemory);
        private object _searchResultsCache = 

        public string OnNewSearch(SearchObject searchObject)
        {
            string searchGuid = _searchCache.AddToCache(searchObject);
            return searchGuid;
        }

        public SearchObject GetSearchObject(string searchId)
        {
            return _searchCache.GetFromCache(searchId);
        }

        public object GetResults(string searchId)
        {

        }
    }
}
