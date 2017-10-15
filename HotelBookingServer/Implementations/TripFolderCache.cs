using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripEngineServiceReference;

namespace HotelBookingServer.Implementations
{
    public static class TripFolderCache
    {
        public static Dictionary<string, TripFolderBookRS> Cache { get; set; } = new Dictionary<string, TripFolderBookRS>();
    }
}
