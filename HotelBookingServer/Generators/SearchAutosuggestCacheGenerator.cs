using HotelBookingServer.Constants;
using HotelBookingServer.Contracts;
using HotelBookingServer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Generators
{
    public static class SearchAutosuggestCacheGenerator
    {
        private static Dictionary<CacheType, ISearchAutoSuggestCache> _generator = new Dictionary<CacheType, ISearchAutoSuggestCache>()
        {
            { CacheType.InMemory,new InMemorySearchAutoSuggestCache()}
        };

        public static ISearchAutoSuggestCache Generate(CacheType inMemory)
        {
            return _generator[inMemory];
        }
    }
}
