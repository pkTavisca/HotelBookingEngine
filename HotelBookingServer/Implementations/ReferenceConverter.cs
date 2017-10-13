using hotel = HotelEngineServiceReference;
using trip = TripEngineServiceReference;
using Newtonsoft.Json;

namespace HotelBookingServer.Implementations
{
    public static class ReferenceConverter
    {
        public static U Convert<T, U>(T obj)
        {
            return JsonConvert.DeserializeObject<U>(JsonConvert.SerializeObject(obj));
        }
    }
}
