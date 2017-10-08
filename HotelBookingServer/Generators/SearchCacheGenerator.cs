using HotelBookingServer.Constants;
using HotelBookingServer.Contracts;
using HotelBookingServer.Implementations;
using System.Collections.Generic;

namespace HotelBookingServer.Generators
{
    public static class SearchCacheGenerator
    {
        private static Dictionary<CacheType, ISearchCache> _generator = new Dictionary<CacheType, ISearchCache>()
        {
            { CacheType.InMemory,new InMemorySearchCache()}
        };

        public static ISearchCache Generate(CacheType searchCacheType)
        {
            return _generator[searchCacheType];
        }
    }
}
