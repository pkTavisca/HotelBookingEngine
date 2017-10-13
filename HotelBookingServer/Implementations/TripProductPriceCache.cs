using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngineServiceReference;

namespace HotelBookingServer.Implementations
{
    public static class TripProductPriceCache
    {
        public static Dictionary<string, TripProductPriceRS> Cache { get; set; } = new Dictionary<string, TripProductPriceRS>();
    }
}
