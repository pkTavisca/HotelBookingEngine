using HotelBookingServer.Constants;
using HotelBookingServer.Contracts;
using HotelBookingServer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingServer.Generators
{
    public static class SearchCacheGenerator
    {
        private static Dictionary<SearchCacheType, ISearchCache> _generator = new Dictionary<SearchCacheType, ISearchCache>()
        {
            { SearchCacheType.InMemory,new InMemorySearchCache()}
        };

        public static ISearchCache Generate(SearchCacheType searchCacheType)
        {
            return _generator[searchCacheType];
        }
    }
}
